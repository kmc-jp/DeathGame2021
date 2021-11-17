using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillAction : ITurnAction
{
    IActor Target
    {
        get;
        set;
    }

    SkillInfo Info
    {
        get;
    }
}
