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

    public void ApplyAdditionalStatus(AdditionalStatus adds)
    {
        this.MaxHp += adds.Hp;
        this.MaxMp += adds.Mp;
        this.Hp += adds.Hp;
        this.Mp += adds.Mp;
        this.Atk += adds.Atk;
        this.Def += adds.Def;
        this.Agi += adds.Agi;
    }

    public static Status GenerateNormalEnemyStatus()
    {
        return new Status(4000, -1, -1, 0, 0); //HP以外仮
    }
}

public struct AdditionalStatus
{
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Agi;
    
    public AdditionalStatus(int hp, int mp, int atk, int def, int agi)
    {
        this.Hp = hp * 10;
        this.Mp = mp * 10;
        this.Atk = atk * 10;
        this.Def = def * 3;
        this.Agi = agi * 10;
    }

    public AdditionalStatus()
    {
        this.Hp = 0;
        this.Mp = 0;
        this.Atk = 0;
        this.Def = 0;
        this.Agi = 0;
    }
}
