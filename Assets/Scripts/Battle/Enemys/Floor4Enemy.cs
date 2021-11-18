
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor4Enemy : RoutinedEnemy
{
    public Floor4Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "仮";
        this.Status = Status.GenerateNormalEnemyStatus();

        BattleManager.Instance.OnTurnEnd(async () =>
        {
            const int recover = 100;
            int actualRecover = Mathf.Min(recover, Status.MaxHp - Status.Hp);
            Status.Hp += actualRecover;
            MessageWindow.Instance.MakeWindow($"{Name} のHPが{actualRecover}回復した！");

            await MessageWindow.Instance.CloseObservable.First();
        })
            .AddTo(behaviour);
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            yield return Random.Range(0, 3) switch
            {
                0 => new AttackToAllAction(this, new ConstDamage(300, 200)),
                1 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(400, 300)),
                2 => new ChargeAction(2f, this),
                _ => throw new NotImplementedException()
            };
        }
    }
}