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
        if (actor.isDead) return;
        int damage = Mathf.Clamp(actor.status.Atk - target.status.Def, 0, target.status.Hp);
        target.status.Hp -= damage;
    }
}
