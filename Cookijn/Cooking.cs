using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : Singleton<Cooking>
{
    [SerializeField] GameObject choppingVFX;

    List<RecipieDeviantSO> deviants = new List<RecipieDeviantSO>();
    List<RecipieSO> allRecipies = new List<RecipieSO>();

    public void Chop()
    {
        //GameObject particle = Instantiate(choppingVFX, transform.position, Quaternion.identity) as GameObject;
        //ParticleSystem vfx = particle.GetComponent<ParticleSystem>();
        //float duration = vfx.main.duration;
        //Destroy(particle, duration);
        //play animation
        Debug.Log("I'm chopping");
    }

    public void Mix(List<Ingredient> currIng)
    {
        CheckRecipies(currIng);
        Debug.Log("I'm mixing");
    }

    public void Heat(List<Ingredient> currIng)
    {
        CheckRecipies(currIng);
        Debug.Log("I'm heating");
    }

    public void CheckRecipies(List<Ingredient> currIng)
    { 
        //check ingredients
        if (deviants.Count == 0)
            //if deviants empty make new list
            deviants = new List<RecipieDeviantSO>(allRecipies);

        //otherwise iterate over old list and get rid of ones
        foreach (Ingredient ing in currIng)
        {

        }
        
        
        //match ingredients by 
        //match proceses
    }
}
