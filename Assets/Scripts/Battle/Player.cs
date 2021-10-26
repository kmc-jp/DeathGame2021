using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IActor
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

    public Player()
    {
        this.status = new Status(100, 100, 20, 5, 5);
    }
}
