
using Cysharp.Threading.Tasks;
using UniRx;

public class Attack
{
    public static async UniTask AttackExec(IActor actor, IActor target, IAttackDamageCalculator damageCalculator)
    {
        if (actor.IsDead) return;
        
        // CoverSkill
        if (target.Buffs.CoveredBy != null) target = target.Buffs.CoveredBy;

        if (target.Buffs.Counter > 0)
        {
            int counterDamage = actor.DealDamage(target.Buffs.Counter);
            MessageWindow.Instance.MakeWindow($"カウンター！\n{actor.Name} は {counterDamage} ダメージを受けた！");
            BattleManager.Instance.UpdatePlayersStatusView();
            
            await MessageWindow.Instance.CloseObservable.First();
            return;
        }
        
        int damage = damageCalculator.Calc(actor, target);
        int actualDamage = target.DealDamage(damage);
        MessageWindow.Instance.MakeWindow($"{target.Name} に {actualDamage} ダメージを与えた！");
        BattleManager.Instance.UpdatePlayersStatusView();

        await MessageWindow.Instance.CloseObservable.First();
    }
}
