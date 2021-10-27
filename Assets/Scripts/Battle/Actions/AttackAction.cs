using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : ITurnAction
{
    public int Priority { get; set; } = 0;
    public Actor Actor
    {
        get;
        set;
    }
    public Actor Target
    {
        get;
        set;
    }

    public AttackAction(Actor _actor, Actor _target)
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

    public void Exec()
    {
        if (Actor.IsDead) return;
        int damage = Actor.Status.Atk - Target.Status.Def;
        if (Target.IsGuard) damage = damage / 3;
        damage = Mathf.Clamp(damage, 0, Target.Status.Hp);
        Target.Status.Hp -= damage;
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
    }
}
