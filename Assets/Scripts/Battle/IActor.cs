using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    string Name { get; }

    Status Status { get; set; }

    bool IsDead { get; }
    
    bool IsGuard { get; set; }

    IActor CoveredBy { get; set; }

    int DealDamage(int value);
}
