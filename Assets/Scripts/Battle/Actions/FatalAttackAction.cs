
using Cysharp.Threading.Tasks;

public class FatalAttackAction : ITurnAction
{
    public int Priority { get; }
    public IActor Actor { get; set; }

    readonly IActor target;
    readonly int damageIfGuarded;

    public FatalAttackAction(IActor actor, IActor target, int damageIfGuarded)
    {
        Actor = actor;
        this.target = target;
        this.damageIfGuarded = damageIfGuarded;
    }
    
    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} のこうげき！");
        return true;
    }

    public UniTask Exec()
    {
        if (target.Buffs.IsGuard)
        {
            return Attack.AttackExec(Actor, target, new ConstDamage(damageIfGuarded, damageIfGuarded));
        }
        
        return Attack.AttackExec(Actor, target, new ConstDamage(1000000, 1000000)); // これで死なないことある？
    }
}