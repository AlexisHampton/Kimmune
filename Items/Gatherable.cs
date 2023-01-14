using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(InteractionManager))]
public class Gatherable : Item
{
    public Sprite itemSprite;
    public bool isCollected;
    // public GameObject pickUpVFX;

    //makes the object inactive
    public void OnCollected()
    {
        if (!isCollected)
        {
            isCollected = true;
            SetKinematic(true);
            gameObject.SetActive(false);
        }
    }

    //drops the gatherable at the target posiiton and turns it active again
    public void OnDropped(Vector3 targetPos, bool isCtrl)
    {
        //if kinematic, than can't collect
        SetKinematic(isCtrl);
        transform.position = targetPos;
        isCollected = !isCtrl;
        transform.SetParent(GameManager.Instance.itemParent);
        gameObject.SetActive(true);
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals((Item)obj)) return false;
        Gatherable other = (Gatherable)obj;
        if (itemSprite != other.itemSprite) return false;
        if (isCollected != other.isCollected) return false;
        return true;
    }
}
