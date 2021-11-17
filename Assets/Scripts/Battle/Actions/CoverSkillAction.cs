using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
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
    
    public override async UniTask Exec()
    {
        if (Actor.IsDead) return;
        Target.Buffs.CoveredBy = Actor;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} は {Target.Name} の身代わりになっている");

        await MessageWindow.Instance.CloseObservable.First();
    }
}
