
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;

public class Floor5Enemy : RoutinedEnemy
{
    public Floor5Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "ジガルド(パーフェクト)";
        this.Status = Status.GenerateNormalEnemyStatus();
        this.Status.Agi = int.MaxValue;

        // int turn = 0;
        // BattleManager.Instance.OnTurnEnd(async () =>
        //     {
        //         Status.Def += 30;
        //         switch (turn % 4)
        //         {
        //             case 0:
        //             {
        //                 Buffs.AttackRate += 1;
        //             }
        //                 break;
        //             case 1:
        //             {
        //                 Buffs.AttackRate += 2;
        //             }
        //                 break;
        //             case 2:
        //             {
        //                 Buffs.AttackRate += 3;
        //             }
        //                 break;
        //             case 3:
        //             {
        //                 // todo: 被ダメ2倍にする
        //             }
        //                 break;
        //             default:
        //                 throw new NotImplementedException();
        //         }
        //     })
        //     .AddTo(behaviour);
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            yield return UnityEngine.Random.Range(0, 3) switch
            {
                0 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(110, 90)),
                1 => new AttacksInARowAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(40, 30), 4),
                2 => new AttackToAllAction(this, new ConstDamage(70, 70)),
                _ => throw new NotImplementedException()
            };
        }
    }
}