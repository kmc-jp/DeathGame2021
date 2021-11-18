
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Floor3EnemyA : RoutinedEnemy
{
    public Floor3EnemyA(EnemyBehaviour behaviour) : base(behaviour)
    {
        this.Name = "仮";
        this.Status = new Status(2500, -1, -1, 0, 0); //HP以外仮
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        while (true)
        {
            yield return Random.Range(0, 3) switch
            {
                0 => new AttackAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(170, 130)),
                1 => new AttacksInARowAction(this, EnemyActionUtil.SelectTarget(), new ConstDamage(100, 80), 4),
                2 => new LaughAction(this),
                _ => throw new NotImplementedException()
            };
        }
    }
}