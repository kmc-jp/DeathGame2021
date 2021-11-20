using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class HealSkillAction : SkillAction
{
    private int healValue
    {
        get => Id switch
            {
                SkillMaster.Heal => 100,
                SkillMaster.HighHeal => 300,
                SkillMaster.FullHeal => 100000,
                _ => 100
            };
    }

    public HealSkillAction(IActor _actor, IActor _target)
    {
        Id = SkillMaster.Heal;
        this.Actor = _actor;
        this.Target = _target;
    }

    public override bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} の {Info.Name}");
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
        int val = healValue;
        if (Actor.Buffs.IsHealBuff) val = val * 2;
        val = Mathf.Clamp(healValue, 0, Target.Status.MaxHp - Target.Status.Hp);
        Target.Status.Hp += val;
        Actor.Status.Mp -= this.Info.Cost;
        MessageWindow.Instance.MakeWindow($"{Target.Name} の体力を {val} 回復");

        await MessageWindow.Instance.CloseObservable.First();
    }
}
