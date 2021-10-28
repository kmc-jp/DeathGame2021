using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Status
{
    public int MaxHp;
    public int MaxMp;
    public ReactiveProperty<int> HpReactive;
    public int Hp
    {
        get { return this.HpReactive.Value; }
        set { this.HpReactive.Value = value; }
    }
    public int Mp;
    public int Atk;
    public int Def;
    public int Agi;

    public Status(int hp, int mp, int atk, int def, int agi)
    {
        this.MaxHp = hp;
        this.MaxMp = mp;
        this.HpReactive = new ReactiveProperty<int>(hp);
        this.Hp = hp;
        this.Mp = mp;
        this.Atk = atk;
        this.Def = def;
        this.Agi = agi;
    }
}
