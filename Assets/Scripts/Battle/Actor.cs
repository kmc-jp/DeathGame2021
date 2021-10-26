using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public Status status
    {
        get;
        set;
    }

    public virtual void SetHp(int value)
    {

    }

    public bool isDead
    {
        get
        {
            return this.status.Hp <= 0;
        }
    }
}
