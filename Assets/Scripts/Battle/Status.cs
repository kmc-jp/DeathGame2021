using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Agi;

    public Status(int hp, int mp, int atk, int def, int agi)
    {
        this.Hp = hp;
        this.Mp = mp;
        this.Atk = atk;
        this.Def = def;
        this.Agi = agi;
    }
}