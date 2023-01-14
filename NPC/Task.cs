using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public string name;
    public int energyDep;
    public int energyRes;
    public Transform location;
    public TaskSO baseTask;

    public override string ToString()
    {
        return " is " + name + "ing.";
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Task)) return false;
        Task other = (Task)obj;
        if (name != other.name) return false;
        if (energyDep != other.energyDep) return false;
        if (energyRes != other.energyRes) return false;
        if (!location.Equals(other.location)) return false;
        if (!baseTask.Equals(other.baseTask)) return false;
        return true;
    }
}
