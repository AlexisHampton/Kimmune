using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds items for every character 
public class Inventory : MonoBehaviour
{
    public List<Item> invItems = new List<Item>(5);
    public int currCap = 0;
    public int invCap;

    public bool isEmpty() { return currCap == 0; }

    //adds a gatherbable to the inventory and increases current capacity
    public void Add(Gatherable newItem)
    {
        if (currCap >= invCap) return;
        //find an empty slot
        int index = InventoryManager.Instance.GetEmptyInventorySlot();

        //if no previous empty spots
        invItems.Insert(index, newItem);
        currCap++;
    }

    //removes gatherable from inventory and decreases current capacity
    public void Remove(Gatherable item)
    {
        if (currCap == 0) return;
        if (invItems.Contains(item))
        {
            invItems.Remove(item);
            currCap--;
        }
    }

    //returns the index of the item 
    public int ItemIndex(Gatherable item)
    {
        return invItems.IndexOf(item);
    }

    //adds the requested item to character hand
    public void PutInHand(Transform hand, Gatherable item)
    {
        item.gameObject.SetActive(true);
        item.transform.SetParent(hand);
        item.transform.position = hand.position;
    }

    //removes item from the characters hand
    public void RemoveFromHand(Player chara)
    {
        if (chara.hand.isHolding)
        {
            chara.hand.itemInHand.gameObject.SetActive(false);
            chara.hand.itemInHand = null;
        }
    }
}
