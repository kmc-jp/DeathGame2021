using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillAction : ITurnAction
{
    string Name { get; }
    int MpCost { get; }
}
