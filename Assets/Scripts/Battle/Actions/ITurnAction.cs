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
    Actor Target
    {
        get;
        set;
    }

    void Exec();
}
