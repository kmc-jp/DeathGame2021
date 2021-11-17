
using Cysharp.Threading.Tasks;
using UniRx;

public class AttacksInARowAction : ITurnAction
{
    public int Priority { get; } = 0;
    public IActor Actor { get; set; }
    IActor Target { get; set; }
    
    readonly IAttackDamageCalculator damageCalculator;

    public AttacksInARowAction(IActor _actor, IActor _target, IAttackDamageCalculator damageCalculator)
    {
        this.Actor = _actor;
        this.Target = _target;
        this.damageCalculator = damageCalculator;
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
        int damage = damageCalculator.Calc(Actor, Target);
        int actualDamage = Target.DealDamage(damage);
        MessageWindow.Instance.MakeWindow($"{Target.Name} に {actualDamage} ダメージを与えた！");

        await MessageWindow.Instance.CloseObservable.First();
    }
}