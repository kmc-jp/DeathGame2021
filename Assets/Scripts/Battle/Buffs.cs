using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs
{
    private IActor Actor;

    public bool IsGuard
    {
        get;
        set;
    }

    public IActor CoveredBy
    {
        get;
        set;
    }

    public Buffs(IActor _actor)
    {
        this.Actor = _actor;
    }

    public bool ProcessBuffs()
    {

        if (IsGuard)
        {
            MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょをといた");
            IsGuard = false;
        }
        if (CoveredBy != null)
        {
            MessageWindow.Instance.MakeWindow($"{CoveredBy.Name} は身代わりをやめた");
            CoveredBy = null;
        }
        return false;
    }
}
