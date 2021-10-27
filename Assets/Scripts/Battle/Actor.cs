using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public string Name;

    public Status Status
    {
        get;
        set;
    }

    public virtual void SetHp(int value)
    {

    }

    public bool IsDead
    {
        get
        {
            return this.Status.Hp <= 0;
        }
    }
}
