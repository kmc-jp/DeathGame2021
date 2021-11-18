
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
        foreach (var _ in Enumerable.Range(0, numAttacks))
        {
            await Attack.AttackExec(Actor, Target, damageCalculator);
        }
    }
}