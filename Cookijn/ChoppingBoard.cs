using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour, IStation
{
    public void OnFinish()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateModel(Ingredient ing)
    {
        ing.Chop();
        Cooking.Instance.Chop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Player player = other.GetComponent<Player>();
            if (!player.hand.isHolding)
            {
                Debug.Log("You need an ingredient to chop!");
                return;
            }
            if (player.hand.itemInHand.GetType() == typeof(Ingredient))
            {
                player.RemoveFromHand(true);
                UpdateModel((Ingredient)player.hand.itemInHand);
            }
        }

    }
}
