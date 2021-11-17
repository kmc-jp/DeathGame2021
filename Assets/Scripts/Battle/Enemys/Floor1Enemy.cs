
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class Floor1Enemy : RoutinedEnemy
{
    public Floor1Enemy(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "仮";
        this.Status = Status.GenerateNormalEnemyStatus();
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            //{
            //    Player target = SelectTarget();
//
            //    int damage = target.Id switch
            //    {
            //        PlayerId.Player => 250,
            //        PlayerId.Buddy => 180,
            //        _ => throw new NotImplementedException()
            //    };
//
            //    yield return new AttackAction(this, target, new ConstDamage(damage));
            //}

            {
                Player target = SelectTarget();

                int damage = target.Id switch
                {
                    PlayerId.Player => 90,
                    PlayerId.Buddy => 70,
                    _ => throw new NotImplementedException()
                };

                yield return new AttacksInARowAction(this, target, new ConstDamage(damage), 4);
            }
        }
    }

    Player SelectTarget()
    {
        Player[] liveTargets = BattleManager.Instance.playerList
            .Where(ally => !ally.IsDead)
            .ToArray();
        int targetIdx = Random.Range(0, liveTargets.Length);
        return liveTargets[targetIdx];
    }
}