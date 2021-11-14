using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : ITurnAction
{
    public int Priority { get; set; } = 0;
    public IActor Actor
    {
        get;
        set;
    }
    public IActor Target
    {
        get;
        set;
    }

    public AttackAction(IActor _actor, IActor _target)
    {
        this.Actor = _actor;
        this.Target = _target;
    }

    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} のこうげき！");
        return true;
    }

    public bool Exec()
    {
        if (Actor.IsDead) return false;
        // CoverSkill
        if (Target.CoveredBy != null) Target = Target.CoveredBy;
        int damage = Target.DealDamage(Actor.Status.Atk);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
        return true;
    }
}
