using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SampleEnemyBehaviour : EnemyBehaviour
{
    void Awake()
    {
        this.EnemyCore = new SampleEnemy(this);
    }

    void Update()
    {
        
    }
}
