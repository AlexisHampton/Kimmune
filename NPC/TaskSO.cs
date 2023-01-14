using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Need {REST, EAT, HYGIENE, FUN}

[CreateAssetMenu(fileName ="Kim Taehyung", menuName = "Task")]
public class TaskSO : ScriptableObject
{
    [Header("Ctrl by SO")]
    public Animation anim;
    public Need need;

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(TaskSO)) return false;
        TaskSO other = (TaskSO)obj;
        if (other.anim != anim) return false;
        if (other.need != need) return false;
        return true;
    }
}
