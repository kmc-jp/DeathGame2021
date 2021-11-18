using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : IActor
{
    public string Name { get; protected set; }

    public Status Status
    {
        get;
        set;
    }
    
    public Buffs Buffs
    {
        get;
        set;
    }

    public bool IsDead
    {
        get
        {
            return this.Status.Hp <= 0;
        }
    }

    public Actor()
    {
        this.Buffs = new Buffs(this);
    }

    public virtual int DealDamage(int value)
    {
        this.Status.Hp -= value;
        return value;
    }
}
