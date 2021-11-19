
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class Floor1Enemy : RoutinedEnemy
{
    public Floor1Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "コタマ";
        this.Status = Status.GenerateNormalEnemyStatus();
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            {
                Player target = EnemyActionUtil.SelectTarget();

                yield return new AttackAction
                (
                    this,
                    target,
                    new ConstDamage(250, 180)
                );
            }

            {
                Player target = EnemyActionUtil.SelectTarget();

                yield return new AttacksInARowAction
                (
                    this,
                    target,
                    new ConstDamage(90, 70),
                    4
                );
            }
            
            yield return new ChargeAction(2.5f, this);
        }
    }
}