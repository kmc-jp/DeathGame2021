using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class AtkBuffSkillAction : SkillAction
{
    public AtkBuffSkillAction(IActor _actor, IActor _target)
    {
        Id = SkillMaster.Cover;
        this.Actor = _actor;
        this.Target = _target;
    }

    public override bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の攻撃力バフ！");
        return true;
    }
    
    public override async UniTask Exec()
    {
        if (Actor.IsDead) return;
        Target.Buffs.AtkBuff += 3;
        MessageWindow.Instance.MakeWindow($"{Target.Name} の攻撃力は3ターンの間増加する！");

        await MessageWindow.Instance.CloseObservable.First();
    }
}
