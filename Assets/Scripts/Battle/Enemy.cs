using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public Enemy()
    {
        this.status = new Status(100, 100, 10, 5, 5);
    }
}
