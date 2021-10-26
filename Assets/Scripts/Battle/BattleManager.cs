using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
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
    private List<GameObject> enemyList;
    private Enemy enemy;

    private List<TurnAction> turnActions;
    
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        turnActions = new List<TurnAction>();
    
        UpdatePlayerStatusView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtackButton()
    {
        turnActions.Add(new TurnAction(player, enemy));
    }

    public void Execute()
    {
        // agi降順にソート
        turnActions.Sort((a, b) => a.actor.status.Agi - b.actor.status.Agi);
        turnActions.ForEach((a)=>
        {
            a.Exec();
            UpdatePlayerStatusView();
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
