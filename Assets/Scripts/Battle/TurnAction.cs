using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAction
{
    public IActor actor;
    public IActor target;

    public TurnAction(IActor _actor, IActor _target)
    {
        this.actor = _actor;
        this.target = _target;
    }

    public void Exec()
    {
        target.status.Hp -= actor.status.Atk - target.status.Def;
    }
}
