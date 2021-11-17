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

    readonly IAttackDamageCalculator damageCalculator;

    public AttackAction(IActor _actor, IActor _target, IAttackDamageCalculator damageCalculator)
    {
        this.Actor = _actor;
        this.Target = _target;
        this.damageCalculator = damageCalculator;
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
        if (Target.Buffs.CoveredBy != null) Target = Target.Buffs.CoveredBy;
        int damage = damageCalculator.Calc(Actor, Target);
        int actualDamage = Target.DealDamage(damage);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {actualDamage} ダメージを与えた！");
        return true;
    }
}

public interface IAttackDamageCalculator
{
    int Calc(IActor attacker, IActor target);
}

public class AttackDamageFromStatus : IAttackDamageCalculator
{
    public int Calc(IActor attacker, IActor target)
    {
        return attacker.Status.Atk;
    }
}

public class ConstDamage : IAttackDamageCalculator
{
    readonly int damage;
    public ConstDamage(int damage)
    {
        this.damage = damage;
    }
    
    public int Calc(IActor attacker, IActor target)
    {
        return damage;
    }
}
