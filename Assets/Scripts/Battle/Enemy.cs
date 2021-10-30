using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : Actor
{
    [SerializeField]
    private GameObject HealthBarImage;
    [SerializeField]
    private Image EnemyImage;
    
    void Start()
    {
        this.Name = "ねこちゃん";
        this.Status = new Status(100, 100, 20, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void DealDamage(int value)
    {
        base.DealDamage(value);
        if (value <= 0) return;
        DamageEffect();
    }

    public ITurnAction Action()
    {
        int index = Random.Range(0, BattleManager.Instance.playerList.Count);
        // TODO: 死んでたらターゲットしない
        var target = BattleManager.Instance.playerList[index];
        return new AttackAction(this, target);
    }

    public void UpdateHealthBar()
    {
        float healthRate = (float)Status.Hp / Status.MaxHp;
        HealthBarImage.transform.localScale = new Vector3(healthRate, 1.0f, 1.0f);
    }

    public void DamageEffect()
    {
        DOTween.Restart(this.EnemyImage);
        this.EnemyImage.DOKill(true);
        this.EnemyImage.DOColor(Color.red, 0.2f).SetLoops(4, LoopType.Yoyo);
    }
}
