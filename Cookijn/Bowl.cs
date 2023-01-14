using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour, IStation 
{ 
    List<Ingredient> ingredients;

    public void OnFinish()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateModel()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Player player = other.GetComponent<Player>();
            if (player.hand.isHolding)
                Cooking.Instance.Mix(ingredients);
            else 
                if (player.hand.itemInHand.GetType() == typeof(Ingredient))
                    ingredients.Add((Ingredient)player.hand.itemInHand);   
        }
    }
}
