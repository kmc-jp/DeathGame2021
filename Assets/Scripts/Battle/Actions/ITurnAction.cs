using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnAction
{
    int Priority
    {
        get;
        set;
    }

    Actor Actor
    {
        get;
        set;
    }

    bool Prepare();
    
    void Exec();
}
