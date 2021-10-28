using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillAction : ITurnAction
{

    Actor Target
    {
        get;
        set;
    }
    
    int MpCost { get; }
}
