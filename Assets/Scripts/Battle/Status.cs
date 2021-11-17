using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public int MaxHp;
    public int MaxMp;
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Agi;

    public Status(int hp, int mp, int atk, int def, int agi)
    {
        this.MaxHp = hp;
        this.MaxMp = mp;
        this.Hp = hp;
        this.Mp = mp;
        this.Atk = atk;
        this.Def = def;
        this.Agi = agi;
    }

    public static Status GenerateNormalEnemyStatus()
    {
        return new Status(4000, -1, -1, 0, 0); //HP以外仮
    }
}
