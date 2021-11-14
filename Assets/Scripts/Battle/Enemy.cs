using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IEnemy
{
    protected EnemyBehaviour behaviour;
    
    public abstract ITurnAction Action();
    
    public override void DealDamage(int value)
    {
        base.DealDamage(value);
        if (value <= 0) return;
        behaviour.DamageEffect();
        behaviour.UpdateHealthBar();
    }
}
