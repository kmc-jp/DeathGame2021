using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : ITurnAction
{
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

    public void Prepare()
    {
        if (Actor.IsDead) return;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} のこうげき！");
    }

    public void Exec()
    {
        if (Actor.IsDead) return;
        int damage = Mathf.Clamp(Actor.Status.Atk - Target.Status.Def, 0, Target.Status.Hp);
        Target.Status.Hp -= damage;
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
    }
}
