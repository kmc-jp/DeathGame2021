using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSkillAction : ISkillAction
{
    public SkillMaster Id = SkillMaster.Cover;
    public string Name 
    { 
        get
        {   
            return SkillService.Instance.SkillNameMaster[Id];
        }
    }
    public int MpCost { get; } = 0;
    public int Priority { get; set; } = 1;

    public IActor Actor { get; set; }

    public IActor Target { get; set; }

    private bool isBreak;
    
    public CoverSkillAction(IActor _actor, IActor _target, bool _isBreak)
    {
        this.Actor = _actor;
        this.Target = _target;
        this.isBreak = _isBreak;
        this.Priority = this.isBreak ? -1 : 1;
    }

    public bool Prepare()
    {
        return false;
    }
    
    public bool Exec()
    {
        if (Actor.IsDead) return false;
        if (isBreak)
        {
            Target.CoveredBy = null;
            MessageWindow.Instance.MakeWindow($"{Actor.Name} は身代わりをやめた");
            return true;
        }
        Target.CoveredBy = Actor;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} は {Target.Name} の身代わりになっている");
        return true;
    }
}
