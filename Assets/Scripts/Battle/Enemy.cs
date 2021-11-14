using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IEnemy
{
    protected EnemyBehaviour behaviour;
    
    public abstract ITurnAction Action();
    
    public override int DealDamage(int value)
    {
        int damage = value - this.Status.Def;
        if (this.IsGuard) damage = damage / 3;
        damage = Mathf.Clamp(damage, 0, this.Status.Hp);
        base.DealDamage(damage);
        behaviour.DamageEffect();
        behaviour.UpdateHealthBar();
        return damage;
    }
}
