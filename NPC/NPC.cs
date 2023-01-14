using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
  
[System.Serializable]
public class NPCNeed
{
    public Need need;
    public int priority;//lower the more important

    //sets priority and caps it at 0 and 100
    public void SetPriority(int amt)
    {
        priority += amt;
        if (priority <= 0)
            priority = 0;
        if (priority >= 100)
            priority = 100;
    }
}

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : Character
{
    //doesn't include job
    public NPCNeed[] npcNeeds = new NPCNeed[4];
    public float distToTask = .05f;


    NavMeshAgent agent;
    NPCNeed currNeed;
    Task currTask;

    //initializes the npc
    public void InitNPC()
    {
        agent = GetComponent<NavMeshAgent>();
        for (int i = 0; i < npcNeeds.Length; i++)
            npcNeeds[i].need = (Need)i;
    }

    //gets a task, goes to its location, and updates energy, and the need
    public void CarryOutTask()
    {
        Task newTask = ScheduleManager.Instance.GetTask(this);
        if (newTask != null)
        {
            if (currTask != null && currTask.Equals(newTask))
            {
                FinishTask(newTask);
                return;
            }
            currTask = newTask;
           // Debug.Log("currTask:" + currTask.name + " " + currTask.location);
            Move(currTask.location);
        }
    }

    //gets the need that has the lowest priority
    public Need GetLowestNeed()
    {
        NPCNeed lowest = npcNeeds[0];
        foreach (NPCNeed npcNeed in npcNeeds)
            if (npcNeed.priority < lowest.priority)
                lowest = npcNeed;
        currNeed = lowest;
        return lowest.need;
    }

    public bool isFull()
    {
        int sum = 0;
        foreach (NPCNeed npcNeed in npcNeeds)
            sum += npcNeed.priority;
        return (sum / npcNeeds.Length) >= 85;

    }

    //lessens the priority for every need
    public void DecreaseNeeds()
    {
        foreach (NPCNeed npcNeed in npcNeeds)
            npcNeed.SetPriority(-5);
    }

    //updates energy and updates the priority for the need in question
    //then gets a new task to carry out
    public void FinishTask()
    {
        FinishTask(currTask);
    }

    //updates energy and updates the priority for the need in question
    //then gets a new task to carry out
    public void FinishTask(Task task)
    {
        int netEnergy = task.energyRes - task.energyDep;
        SetEnergy(netEnergy);
        currNeed.SetPriority(Mathf.Abs(netEnergy)); //if we complete a task, we shouldn't have to repeat it
        //Debug.Log(name + " " + task.ToString());
        CarryOutTask();
    }

    //travels to the npc's home
    public void GoHome()
    {
        Move(home.transform);
    }

    //goes to the indicated location
    private void Move(Transform trans)
    {
        agent.SetDestination(trans.transform.position);
    }

    public bool ReachedDestination()
    {
        return agent.remainingDistance <= distToTask;
    }
}
