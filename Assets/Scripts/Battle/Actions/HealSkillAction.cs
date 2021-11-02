using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSkillAction : ISkillAction
{
    public SkillMaster Id = SkillMaster.Heal;
    public string Name 
    { 
        get
        {   
            return SkillService.Instance.SkillNameMaster[Id];
        }
    }
    public int MpCost { get; } = 5;
    public int Priority { get; set; } = 0;
    private int healValue = 100;

    public Actor Actor { get; set; }

    public Actor Target { get; set; }

    public HealSkillAction(Actor _actor, Actor _target)
    {
        this.Actor = _actor;
        this.Target = _target;
    }

    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の {Name}");
        return true;
    }
    
    public bool Exec()
    {
        if (Actor.IsDead) return false;
        int val = Mathf.Clamp(healValue, 0, Target.Status.MaxHp - Target.Status.Hp);
        Target.Status.Hp += val;
        Actor.Status.Mp -= this.MpCost;
        MessageWindow.Instance.MakeWindow($"{Target.Name} の体力を {val} 回復");
        return true;
    }
}
