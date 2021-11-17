using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedAttackSkillAction : ISkillAction
{
    public SkillMaster Id = SkillMaster.EnhancedAttack;
    public string Name 
    { 
        get
        {   
            return SkillService.Instance.SkillNameMaster[Id];
        }
    }
    public int MpCost { get; } = 5;
    public int Priority { get; set; } = 0;

    public IActor Actor { get; set; }

    public IActor Target { get; set; }
    
    public EnhancedAttackSkillAction(IActor _actor, IActor _target)
    {
        this.Actor = _actor;
        this.Target = _target;
    }

    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の属性攻撃！");
        return true;
    }
    
    public bool Exec()
    {
        if (Actor.IsDead) return false;
        if (Target.Buffs.CoveredBy != null) Target = Target.Buffs.CoveredBy;
        Actor.Status.Mp -= this.MpCost;
        int damage = Target.DealDamage(Actor.Status.Atk + 100);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");
        return true;
    }
}
