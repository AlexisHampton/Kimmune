using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStation
{
    public void OnFinish();
    public void UpdateModel(Ingredient ing);
    //public void UpdateModel();
}
