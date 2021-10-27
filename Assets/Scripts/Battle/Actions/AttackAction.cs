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
        if (Actor.isDead) return;
        MessageWindow.Instance.MakeWindow("攻撃するよ");
    }

    public void Exec()
    {
        if (Actor.isDead) return;
        int damage = Mathf.Clamp(Actor.status.Atk - Target.status.Def, 0, Target.status.Hp);
        Target.status.Hp -= damage;
        MessageWindow.Instance.MakeWindow($"{damage} ダメージを与えた！");
    }
}
