using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum StepType { MIX, CHOP, HEAT, ADD }

[System.Serializable]
//contains the steps for each part of the recipie
public class Step
{
    public Ingredient ingredient;
    public StepType stepType;

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Step)) return false;
        Step other = (Step)obj;
        if (ingredient != other.ingredient) return false;
        if (stepType != other.stepType) return false;
        return true;
    }
}

[CreateAssetMenu(fileName ="Kim Namjoon", menuName = "Recipie Deviant")]
public class RecipieDeviantSO : ScriptableObject
{
    public bool canBeDoneOutofOrder;
    public List<Step> reqSteps;
    public List<Ingredient> reqIngredients;
    public List<IngredientType> miscIng;
    public int score;
    public Gatherable mixedObject;
    public Gatherable heatedObject;

    //checks if the recipie contains a provided ingredient
    //1 == reqIng
    //0 == miscIng
    //-1 if false
    public int ContainsIngredient(Ingredient ing)
    {
        //check reIng
        foreach (Ingredient ingredient in reqIngredients)
            if (ingredient.Equals(ing))
                return 1;
        //check miscIng
        foreach (IngredientType ingType in miscIng)
            if (ing.ingredientType == ingType)
                return 0;
        return -1;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(RecipieDeviantSO)) return false;
        RecipieDeviantSO other = (RecipieDeviantSO)obj;
        if (canBeDoneOutofOrder != other.canBeDoneOutofOrder) return false;
        if (reqIngredients.SequenceEqual(other.reqIngredients)) return false;
        if (reqSteps.SequenceEqual(other.reqSteps)) return false;
        if (miscIng.SequenceEqual(other.miscIng)) return false;
        return true;
    }

    public int CalculateScore()
    {
        score = 0;
        score += reqIngredients.Count + reqSteps.Count + miscIng.Count;
        //eventually, maybe on ingredient rarity?
        return score;
    }

}
