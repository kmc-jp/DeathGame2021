using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedAttackSkillAction : SkillAction
{
    private int influence = 100;
    
    public EnhancedAttackSkillAction(IActor _actor, IActor _target)
    {
        this.Id = SkillMaster.EnhancedAttack;
        this.Actor = _actor;
        this.Target = _target;
    }

    public override bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の属性攻撃！");
        return true;
    }
    
    public override bool Exec()
    {
        if (Actor.IsDead) return false;
        if (Target.Buffs.CoveredBy != null) Target = Target.Buffs.CoveredBy;
        Actor.Status.Mp -= this.Info.Cost;
        int damage = Target.DealDamage(Actor.Status.Atk + influence);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
        return true;
    }
}
