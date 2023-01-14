using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType { DIALOGUE, ITEM, STATION}

public class InteractionManager : MonoBehaviour
{
    public InteractionType interactionType;

   

    private void OnTriggerEnter(Collider other)
    {
        //if player and presses f
            if(other.GetComponent<Player>())
                CheckInteraction(other.GetComponent<Player>());
        //if npc, 

    }

    private void CheckInteraction(Player chara)
    {
        switch (interactionType)
        {
            case InteractionType.DIALOGUE:
                Debug.Log("Trying to dialogue");
                break;
            case InteractionType.ITEM:
                Gatherable item = GetComponent<Gatherable>();
                if (!item.isCollected)
                {
                    chara.inventory.Add(item);
                    InventoryManager.Instance.UpdateUI(item, chara);
                    item.OnCollected();
                }
                Debug.Log("You already have this item!!!!"); //make this a oneliner thing
                break;
            case InteractionType.STATION:
                Debug.Log("trying");
                break;
            default:

                break;
        }
    }
}
