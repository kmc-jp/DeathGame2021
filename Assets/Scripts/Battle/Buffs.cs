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
            MessageWindow.Instance.AddMessage($"{Actor.Name} はぼうぎょをといた");
            IsGuard = false;
        }
        if (CoveredBy != null)
        {
            MessageWindow.Instance.AddMessage($"{CoveredBy.Name} は身代わりをやめた");
            CoveredBy = null;
        }
        return false;
    }
}
