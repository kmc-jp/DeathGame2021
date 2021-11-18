using System;
using UnityEngine;

public class NormalEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] int floor;
    [SerializeField] int enemyIndex;
    void Awake()
    {
        this.EnemyCore = floor switch
        {
            1 => new Floor1Enemy(this),
            2 => new Floor2Enemy(this),
            3 => enemyIndex switch
            {
                1 => new Floor3EnemyA(this),
                2 => new Floor3EnemyB(this),
                _ => throw new NotImplementedException()
            },
            4 => new Floor4Enemy(this),
            5 => new Floor5Enemy(this),
            6 => new Floor6Enemy(this),
            7 => new Boss(this),
            _ => throw new NotImplementedException()
        };
    }
}