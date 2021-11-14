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

    public bool IsDead
    {
        get
        {
            return this.Status.Hp <= 0;
        }
    }
    
    public bool IsGuard
    {
        get;
        set;
    }

    public IActor CoveredBy
    {
        get;
        set;
    }

    public virtual int DealDamage(int value)
    {
        this.Status.Hp -= value;
        return value;
    }
}
