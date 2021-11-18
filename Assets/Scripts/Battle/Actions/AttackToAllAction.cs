
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;

public class AttackToAllAction : ITurnAction
{
    public int Priority { get; }
    public IActor Actor { get; set; }

    readonly IAttackDamageCalculator damageCalculator;

    public AttackToAllAction(IActor actor, IAttackDamageCalculator damageCalculator)
    {
        Actor = actor;
        this.damageCalculator = damageCalculator;
    }
    
    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} のぜんたいこうげき！");
        return true;
    }

    public async UniTask Exec()
    {
        if (Actor.IsDead) return;

        var targets = BattleManager.Instance.playerList
            .Where(player => !player.IsDead)
            .Select(player => player.Buffs.CoveredBy ?? player);

        foreach (IActor target in targets)
        {
            if(target.IsDead) continue;

            await Attack.AttackExec(Actor, target, damageCalculator);
        }
    }
}