using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    string Name { get; }

    Status Status { get; set; }

    Buffs Buffs { get; set; }

    bool IsDead { get; }

    int DealDamage(int value);
}
