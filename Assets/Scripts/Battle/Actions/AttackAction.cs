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
        int damage = Actor.Status.Atk - Target.Status.Def;
        if (Target.IsGuard) damage = damage / 3;
        damage = Mathf.Clamp(damage, 0, Target.Status.Hp);
        Target.DealDamage(damage);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
        return true;
    }
}
