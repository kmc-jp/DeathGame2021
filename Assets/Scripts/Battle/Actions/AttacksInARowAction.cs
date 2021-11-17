
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class AttacksInARowAction : ITurnAction
{
    public int Priority { get; } = 0;
    public IActor Actor { get; set; }
    IActor Target { get; set; }
    
    readonly IAttackDamageCalculator damageCalculator;
    readonly int numAttacks;

    public AttacksInARowAction(IActor _actor, IActor _target, IAttackDamageCalculator damageCalculator, int numAttacks)
    {
        this.Actor = _actor;
        this.Target = _target;
        this.damageCalculator = damageCalculator;
        this.numAttacks = numAttacks;
    }
    
    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} のれんぞくこうげき！");
        return true;
    }

    public async UniTask Exec()
    {
        if (Actor.IsDead) return;
        // CoverSkill
        if (Target.Buffs.CoveredBy != null) Target = Target.Buffs.CoveredBy;

        foreach (var _ in Enumerable.Range(0, numAttacks))
        {
            if (Actor.IsDead) return;
            
            int damage = damageCalculator.Calc(Actor, Target);
            int actualDamage = Target.DealDamage(damage);
            
            MessageWindow.Instance.MakeWindow($"{Target.Name} に {actualDamage} ダメージを与えた！");
            BattleManager.Instance.UpdatePlayersStatusView();
            await MessageWindow.Instance.CloseObservable.First();
        }
    }
}