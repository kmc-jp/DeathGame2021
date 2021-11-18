
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Floor2Enemy : RoutinedEnemy
{
    public Floor2Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "仮";
        this.Status = Status.GenerateNormalEnemyStatus();
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            int zero_one = Random.Range(0, 2);
            if (zero_one == 0)
            {
                Player target = EnemyActionUtil.SelectTarget();

                yield return new AttackAction
                (
                    this,
                    target,
                    new ConstDamage(250, 180)
                );
            }
            else
            {
                // カウンター
                // todo
                yield return new ChargeAction(2.5f, this);
            }
            
            zero_one = Random.Range(0, 2);
            if (zero_one == 0)
            {
                // 全体攻撃
                yield return new AttackToAllAction(this, new ConstDamage(150, 150));
            }
            else
            {
                // 連続攻撃
                Player target = EnemyActionUtil.SelectTarget();
                yield return new AttacksInARowAction(this, target, new ConstDamage(90, 70), 4);
            }
            
            // 強攻撃
        }
    }
}