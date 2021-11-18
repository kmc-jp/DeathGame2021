
using System.Collections.Generic;

public class Boss : RoutinedEnemy
{
    public Boss(EnemyBehaviour behaviour) : base(behaviour)
    {
    }

    protected override IEnumerator<ITurnAction> GetRoutine()
    {
        throw new System.NotImplementedException();
    }
}