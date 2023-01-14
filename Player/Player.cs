using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Transform droppedOffset;

    private void Update()
    {

        //r for remove from first hand
        if (Input.GetKeyUp(KeyCode.R))
        {
            RemoveFromHand(true);
        }
    }

    public void Move()
    {

    }

    public override void AddToHand(Gatherable item)
    {
        if (item != null)
        {
            inventory.RemoveFromHand(this);
            inventory.PutInHand(hand.handPos, item);
            base.AddToHand(item);
        }
    }

    public void RemoveFromHandFroUI()
    {
        inventory.RemoveFromHand(this);
    }

    public void RemoveFromHand(bool isControlled)
    {
        if (!inventory.isEmpty() && hand.isHolding)
        {
            Gatherable item = hand.itemInHand;
            inventory.Remove(item);
            inventory.RemoveFromHand(this);
            item.OnDropped(droppedOffset.position, false);
            InventoryManager.Instance.currInvenSlot.Remove();
        }
    }
}
