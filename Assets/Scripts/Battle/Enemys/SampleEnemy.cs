using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SampleEnemy : Actor, IEnemy
{
    private EnemyBehaviour behaviour;
    
    public SampleEnemy(EnemyBehaviour _behaviour)
    {
        this.Name = "ねこちゃん";
        this.Status = new Status(100, 100, 20, 5, 5);
        this.behaviour = _behaviour;
    }

    public override void DealDamage(int value)
    {
        base.DealDamage(value);
        if (value <= 0) return;
        behaviour.DamageEffect();
        behaviour.UpdateHealthBar();
    }

    public ITurnAction Action()
    {
        int index = Random.Range(0, BattleManager.Instance.playerList.Count);
        // TODO: 死んでたらターゲットしない
        var target = BattleManager.Instance.playerList[index];
        return new AttackAction(this, target);
    }
}
