using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : Actor
{
    private EnemyBehaviour behaviour;
    
    public Enemy(EnemyBehaviour _behaviour)
    {
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
