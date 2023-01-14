using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    List<NPC> npcs = new List<NPC>();
    public Transform itemParent;

    private void Start()
    {
        NPC[] tempnpcs = FindObjectsOfType<NPC>();
        for (int i = 0; i < tempnpcs.Length; i++)
            npcs.Add(tempnpcs[i]);
        foreach (NPC npc in npcs)
        {
            npc.InitNPC();
            RandomizeNeedPriority(npc);
            npc.CarryOutTask();
        }
    }

    void RandomizeNeedPriority(NPC npc)
    {
        for(int i = 0; i < npc.npcNeeds.Length;i++)
        {
            int rand = Random.Range(0, 100);
            npc.npcNeeds[i].priority = rand;
        }
    }

}
