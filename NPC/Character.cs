using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race { ELF, SHSTRAFF, LHSTRAFF }

[System.Serializable]
public class Hand
{
    public Transform handPos;
    public Gatherable itemInHand;
    public bool isHolding { get { return itemInHand != null; } }
}

public class Character : MonoBehaviour
{
    [Header("Character")]
    public Race race;
    public int energy;
    public Home home;

    [Header("Inventory")]
    public Inventory inventory;
    public Hand hand;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    //sets and caps energy to 0 or 100
    public void SetEnergy(int e)
    {
        energy += e;
        if (energy <= 0)
            energy = 0;
        if (energy >= 100)
            energy = 100;
    }

    public virtual void AddToHand(Gatherable item)
    {
        hand.itemInHand = item;
    }

}
