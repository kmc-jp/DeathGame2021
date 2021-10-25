using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private Player player;
    private Enemy enemy;

    private List<TurnAction> turnActions;
    
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        enemy = new Enemy();
        turnActions = new List<TurnAction>();
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
        turnActions.ForEach((a)=>
        {
            a.Exec();
        });
        turnActions.Clear();
        Debug.Log(enemy.status.Hp);
    }
}
