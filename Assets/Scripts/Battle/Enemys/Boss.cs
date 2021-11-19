
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Boss : RoutinedEnemy
{
    public Boss(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "グラゴス";
        this.Status = new Status(5000, -1, -1, 0, 0);
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            yield return new DoubleAction(OneAction(), OneAction());
            yield return new DoubleAction(OneAction(), OneAction());
            yield return new DoubleAction(OneAction(), OneAction());
            yield return new DoubleAction(OneAction(), OneAction());
            yield return new DoubleAction(new FatalAttackAction(this, EnemyActionUtil.SelectTarget(), 50), OneAction());
        }
    }
    
    ITurnAction OneAction() => Random.Range(0, 4) switch
    {
        0 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(250, 150)),
        1 => new AttackToAllAction(this, new ConstDamage(200, 130)),
        2 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(350, 200)),
        3 => new AttacksInARowAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(80, 60), ((Random.Range(0, 2) == 0) ? 3 : 4)),
        _ => throw new NotImplementedException()
    };
}