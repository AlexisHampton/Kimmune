using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Park Jimin", menuName = "Recipie")]
public class RecipieSO : RecipieDeviantSO
{
    public List<Step> requiredSteps = new List<Step>();
    public List<RecipieDeviantSO> deviants;

    //finds all the recipies with the required ingredients 
    public List<RecipieDeviantSO> FindRecipies(Ingredient ing)
    {
        List<RecipieDeviantSO> devs = new List<RecipieDeviantSO>();
        //add the deviants if the ingredients match
        foreach (RecipieDeviantSO dev in deviants)
            if (dev.ContainsIngredient(ing) != 0)
                devs.Add(dev);
        //if this super recipie can be added, add it
        if (ContainsIngredient(ing) != 0)
            devs.Add(this);

        return devs;
    }

    //checks if the incoming step is part of the steps 
    public bool ContainsStep(Step inStep)
    {
        //if it contains the step, the recipie will be considered
        foreach(Step step in reqSteps)
            if (step.Equals(inStep))
                return true;
        return false;
    }

    public override bool Equals(object obj)
    {
        if(!base.Equals(obj)) return false;
        RecipieSO other = (RecipieSO)obj;
        if (!deviants.SequenceEqual(other.deviants)) return false;
        return true;
    }
}
