using System;
using UnityEngine;

public class NormalEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] int floor;
    void Awake()
    {
        this.EnemyCore = floor switch
        {
            1 => new Floor1Enemy(this),
            2 => new Floor2Enemy(this),
            _ => throw new NotImplementedException()
        };
    }
}