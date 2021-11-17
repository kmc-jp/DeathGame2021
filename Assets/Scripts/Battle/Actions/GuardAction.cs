using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAction : ITurnAction
{
    public int Priority { get; set; } = 1;
    private bool isBreak;
    public IActor Actor
    {
        get;
        set;
    }

    public GuardAction(IActor _actor)
    {
        this.Actor = _actor;
    }

    public bool Prepare()
    {
        return false;
    }

    public bool Exec()
    {
        if (Actor.IsDead) return false;
        Actor.Buffs.IsGuard = true;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} はぼうぎょしている！");
        return true;
    }
}
