using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    [SerializeField]
    private DisplayStatus playerStatusView;
    private Player player;
    /*
    [SerializeField]
    private DisplayStatus buddyStatusView;
    private Player buddy;
    */
    [SerializeField]
    private List<EnemyBehaviour> enemyList = new List<EnemyBehaviour>();
    private Enemy enemy;

    private List<ITurnAction> turnActions;
    
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        enemy = enemyList[0].EnemyCore;
        turnActions = new List<ITurnAction>();
    
        UpdatePlayerStatusView();
    }

    public void AttackButton()
    {
        turnActions.Add(new AttackAction(player, enemy));
    }

    public void Execute()
    {
        // agi降順にソート
        turnActions.Sort((a, b) => a.Actor.status.Agi - b.Actor.status.Agi);
        turnActions.ForEach((a)=>
        {
            a.Exec();
            UpdatePlayerStatusView();
            enemyList.ForEach((e) => 
            {
                e.UpdateHealthBar();
            });
        });
        turnActions.Clear();
        Debug.Log(enemy.status.Hp);
    }

    private void UpdatePlayerStatusView()
    {
        playerStatusView.SetHpText(player.status.Hp.ToString());
        playerStatusView.SetMpText(player.status.Mp.ToString());
    }
}
