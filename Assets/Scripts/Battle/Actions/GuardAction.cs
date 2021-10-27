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

    public GuardAction(Actor _actor, bool _isBreak, int _priority)
    {
        this.Actor = _actor;
        this.isBreak = _isBreak;
        this.Priority = _priority;
    }

    public bool Prepare()
    {
        return false;
    }

    public void Exec()
    {
        if (Actor.IsDead) return;
        if (isBreak)
        {
            Actor.IsGuard = false;
            MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょをといた");
            return;
        }
        Actor.IsGuard = true;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょしている！");
    }
}
