using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public List<Task> Tasks { get { return tasks; } }

    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Task task in tasks)
            task.location = transform;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        NPC npc = other.GetComponentInParent<NPC>();
        if (npc != null)
            npc.FinishTask();
    }

    public void SetKinematic(bool isOn)
    {
        rb.isKinematic = isOn;
    }

    //checks if two items are equal
    public override bool Equals(object obj)
    {
        //if (obj.GetType() != typeof(Item)) return false;
        Item other = (Item) obj;
        Debug.Log( "equal"+tasks.SequenceEqual(other.tasks));
        if (!tasks.SequenceEqual(other.tasks)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
