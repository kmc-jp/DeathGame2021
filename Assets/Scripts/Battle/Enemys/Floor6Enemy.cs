
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using Random = UnityEngine.Random;

public class Floor6Enemy : RoutinedEnemy
{
    public Floor6Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "キャットシー";
        this.Status = Status.GenerateNormalEnemyStatus();
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            yield return new DoubleAction(OneAction(), OneAction());
        }
    }

    ITurnAction OneAction() => Random.Range(0, 3) switch
    {
        0 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(220, 150)),
        1 => new AttacksInARowAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(150, 110), 2),
        2 => new AttackToAllAction(this, new ConstDamage(180, 180)),
        _ => throw new NotImplementedException()
    };

}
