using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSkillAction : SkillAction
{
    public CoverSkillAction(IActor _actor, IActor _target)
    {
        Id = SkillMaster.Cover;
        this.Actor = _actor;
        this.Target = _target;
    }

    public override bool Prepare()
    {
        return false;
    }
    
    public override bool Exec()
    {
        if (Actor.IsDead) return false;
        Target.Buffs.CoveredBy = Actor;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} は {Target.Name} の身代わりになっている");
        return true;
    }
}
