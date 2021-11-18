
using System.Collections.Generic;

public abstract class RoutinedEnemy : Enemy
{
    readonly IEnumerator<ITurnAction> routine;

    public RoutinedEnemy(EnemyBehaviour behaviour)
    {
        this.behaviour = behaviour;
        routine = GetRoutine();
    }
    
    public override ITurnAction Action()
    {
        routine.MoveNext();
        return routine.Current;
    }

    protected abstract IEnumerator<ITurnAction> GetRoutine();
}