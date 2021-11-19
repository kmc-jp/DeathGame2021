using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs
{
    private IActor Actor;

    public float AttackRate
    {
        get;
        set;
    }
        = 1;

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

    public int Counter
    {
        get;
        set;
    }

    // 一旦AttackRateとは別の実装をする
    public int AtkBuff
    {
        get;
        set;
    }

    public bool IsAtkBuff
    {
        get => AtkBuff > 0;
    }

    public int HealBuff
    {
        get;
        set;
    }

    public bool IsHealBuff
    {
        get => HealBuff > 0;
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
        if (Counter > 0)
        {
            MessageWindow.Instance.AddMessage($"{Actor.Name} はカウンターの構えをやめた");
            Counter = 0;
        }
        if (IsAtkBuff)
        {
            AtkBuff--;
            if (!IsAtkBuff) MessageWindow.Instance.AddMessage($"{Actor.Name} の攻撃上昇が解けた");
        }
        if (IsHealBuff)
        {
            HealBuff--;
            if (!IsHealBuff) MessageWindow.Instance.AddMessage($"{Actor.Name} の回復上昇が解けた");
        }
        return false;
    }
}
