using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    Status status
    {
        get;
        set;
    }
    
    bool isDead
    {
        get;
    }
}
