using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;


public class EnemyBehaviour : Actor
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

    public ITurnAction Action()
    {
        int index = Random.Range(0, BattleManager.Instance.players.Count);
        var target = BattleManager.Instance.players[index];
        return new AttackAction(this, target);
    }

    public void UpdateHealthBar()
    {
        float healthRate = (float)Status.Hp / Status.MaxHp;
        HealthBarImage.transform.localScale = new Vector3(healthRate, 1.0f, 1.0f);
    }
}
