using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAction : ITurnAction
{
    public int Priority { get; set; }
    private bool isBreak;
    public Actor Actor
    {
        get;
        set;
    }

    public GuardAction(Actor _actor, bool _isBreak)
    {
        this.Actor = _actor;
        this.isBreak = _isBreak;
        this.Priority = this.isBreak ? -1 : 1;
    }

    public bool Prepare()
    {
        return false;
    }

    public bool Exec()
    {
        if (Actor.IsDead) return false;
        if (isBreak)
        {
            Actor.IsGuard = false;
            MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょをといた");
            return true;
        }
        Actor.IsGuard = true;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょしている！");
        return true;
    }
}
