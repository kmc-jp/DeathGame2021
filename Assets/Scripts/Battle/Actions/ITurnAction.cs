using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnAction
{
    Actor Actor
    {
        get;
        set;
    }

    void Prepare();
    
    void Exec();
}
