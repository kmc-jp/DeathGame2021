using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class EnhancedAttackSkillAction : SkillAction
{
    private int influence = 100;
    
    public EnhancedAttackSkillAction(IActor _actor, IActor _target)
    {
        this.Id = SkillMaster.EnhancedAttackP;
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
        if (Target.Buffs.CoveredBy != null) Target = Target.Buffs.CoveredBy;
        Actor.Status.Mp -= this.Info.Cost;
        int d = (int) ((Actor.Status.Atk + influence) * Actor.Buffs.AttackRate);
        if (Actor.Buffs.IsAtkBuff) d = d * 2;
        int damage = Target.DealDamage(d);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {damage} ダメージを与えた！");

        await MessageWindow.Instance.CloseObservable.First();
    }
}
