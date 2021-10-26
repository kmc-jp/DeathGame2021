using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IActor
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
            return this.status.Hp > 0;
        }
    }

    public Enemy()
    {
        this.status = new Status(100, 100, 10, 5, 5);
    }
}
