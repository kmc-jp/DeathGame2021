using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor: MonoBehaviour
{
    public string Name;

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
}
