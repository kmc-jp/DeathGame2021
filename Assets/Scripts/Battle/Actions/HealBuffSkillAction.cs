using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class HealBuffSkillAction : SkillAction
{
    public HealBuffSkillAction(IActor _actor, IActor _target)
    {
        Id = SkillMaster.HealBuff;
        this.Actor = _actor;
        this.Target = _target;
    }

    public override bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の {Info.Name}！");
        return true;
    }
    
    public override async UniTask Exec()
    {
        if (Actor.IsDead) return;
        if (Actor.Status.Mp < Info.Cost)
        {
            MessageWindow.Instance.MakeWindow($"しかしMPが足りなかった！");
            await MessageWindow.Instance.CloseObservable.First();
            return;
        }
        Actor.Status.Mp -= this.Info.Cost;
        Target.Buffs.HealBuff += 3;
        MessageWindow.Instance.MakeWindow($"{Target.Name} の回復力は3ターンの間増加する！");

        await MessageWindow.Instance.CloseObservable.First();
    }
}
