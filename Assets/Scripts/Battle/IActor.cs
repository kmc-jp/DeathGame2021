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

    public bool isDead
    {
        get
        {
            return this.status.Hp <= 0;
        }
    }
}
