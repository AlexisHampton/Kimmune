using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public Player player;
    public InventorySlot[] inventorySlots;
    public InventorySlot currInvenSlot;

    public void AddToHand(InventorySlot slot)
    {
        if (slot.isEmpty())
        {
            player.RemoveFromHandFroUI();
            return;
        }
        currInvenSlot = slot;
        player.AddToHand(slot.item);
    }

    public void UpdateUI(Gatherable item, Character chara)
    {
        int index = chara.inventory.ItemIndex(item);
        inventorySlots[index].AddToSlot(item);
    }

    //returns any empty inventory slot 
    public int GetEmptyInventorySlot()
    {
        for(int i = 0; i < inventorySlots.Length;i++)
            if (!inventorySlots[i].isFull)
                return i;
        return -1; // no empty slot found
    }
}
