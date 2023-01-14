using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType { VEG, FRUIT, HERB, MEAT, LIQUID, WATER, SWEET, DAIRY}

public class Ingredient : Gatherable
{
    [Header("Info")]
    public IngredientType ingredientType;
    public List<StepType> ProcessedSteps { get { return processedSteps; } }
    public int freshness; //out of 100

    [Header("Models")]
    [SerializeField] Mesh choppedMesh;
    [SerializeField] MeshFilter meshFilter;

    List<StepType> processedSteps = new List<StepType>();

    public void DecreaseFreshness(int f)
    {
        freshness -= f;
        if (freshness <= 0)
            freshness = 0;
    }

    public void AddStep(StepType stepType)
    {
        if (!processedSteps.Contains(stepType))
            processedSteps.Add(stepType);
    }

    public void Chop()
    {
        meshFilter.mesh = choppedMesh;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Ingredient)) return false;
        Ingredient other = (Ingredient)obj;
        if (ingredientType != other.ingredientType) return false;
        if (freshness != other.freshness) return false;
        foreach (StepType stepType in processedSteps)
            if (!other.processedSteps.Contains(stepType))
                return false;
        return true;
    }

}
