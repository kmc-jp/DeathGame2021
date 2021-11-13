using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    protected EnemyBehaviour behaviour;
    
    public override void DealDamage(int value)
    {
        base.DealDamage(value);
        if (value <= 0) return;
        behaviour.DamageEffect();
        behaviour.UpdateHealthBar();
    }
}
