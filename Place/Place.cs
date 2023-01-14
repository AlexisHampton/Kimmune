using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Need need;
    public List<Task> tasks = new List<Task>();

    //gets all the items attached to the place
    private void Awake()
    {
        Item[] items = GetComponentsInChildren<Item>();
        foreach(Item item in items)
            foreach (Task task in item.Tasks)
                tasks.Add(task);
        
    }

}
