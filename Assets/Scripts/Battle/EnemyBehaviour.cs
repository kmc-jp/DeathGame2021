using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject HealthBarImage;
    public Enemy EnemyCore{
        get;
        set;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.EnemyCore = new Enemy("ねこちゃん", new Status(100, 100, 20, 5, 5));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public ITurnAction Action()
    {
        int index = Random.Range(0, BattleManager.Instance.players.Count);
        var target = BattleManager.Instance.players[index];
        return new AttackAction(EnemyCore, target);
    }

    public void UpdateHealthBar()
    {
        float healthRate = (float)EnemyCore.Status.Hp / EnemyCore.Status.MaxHp;
        HealthBarImage.transform.localScale = new Vector3(healthRate, 1.0f, 1.0f);
    }
}
