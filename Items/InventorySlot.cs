using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Gatherable item;
    public Image itemSlotImg;
    public bool isFull;

    //checks if a slot is available
    public bool isEmpty() { return item == null; }

    public bool Contains(Gatherable i)
    {
        if (item != null)
            return item.Equals(i);
        return false;
    }

    public void AddToSlot(Gatherable i)
    {
        item = i;
        itemSlotImg.sprite = item.itemSprite;
        isFull = true;
    }

    public void Remove()
    {
        item = null;
        itemSlotImg.sprite = null;
        isFull = false;
    }
}
