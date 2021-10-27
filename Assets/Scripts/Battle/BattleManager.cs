using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    [SerializeField]
    private DisplayStatus playerStatusView;
    private Player player;
    
    [SerializeField]
    private DisplayStatus buddyStatusView;
    private Player buddy;

    public List<Player> players;
    
    [SerializeField]
    private List<EnemyBehaviour> enemyList;
    private Enemy enemy;

    private List<ITurnAction> turnActions;

    private int commandOrder = 0;
    
    void Start()
    {
        player = new Player("主人公", new Status(500, 100, 20, 10, 10));
        buddy = new Player("相棒", new Status(350, 300, 20, 10, 10));
        players = new List<Player>();
        players.Add(player);
        players.Add(buddy);
        turnActions = new List<ITurnAction>();
        UpdatePlayersStatusView();
    }

    public void AttackButton()
    {
        enemy = enemyList[0].EnemyCore;
        Actor actor = players[commandOrder];
        turnActions.Add(new AttackAction(actor, enemy));
        if (commandOrder >= 1) Execute();
        commandOrder ++;
    }

    public void GuardButton()
    {
        Actor actor = players[commandOrder];
        turnActions.Add(new GuardAction(actor, false, 1));
        turnActions.Add(new GuardAction(actor, true, -1));
        if (commandOrder >= 1) Execute();
        commandOrder ++;
    }

    public void Execute()
    {
        enemyList.ForEach((e) =>
        {
            turnActions.Add(e.Action());
        });
        StartCoroutine(ExecuteCore());
    }

    private IEnumerator ExecuteCore()
    {
        // agi降順にソート
        var orderdTurnActions = turnActions
            .OrderByDescending(val => { return val.Priority; })
            .ThenBy(val => { return -val.Actor.Status.Agi; });
        foreach (var a in orderdTurnActions)
        {
            if (a.Prepare())
            {
                yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
            }
            a.Exec();
            yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
            UpdatePlayersStatusView();
            enemyList.ForEach((e) => 
            {
                e.UpdateHealthBar();
            });

            bool clear = true;
            foreach (var e in enemyList) { clear &= e.EnemyCore.IsDead; }
            if (clear) 
            {
                MessageWindow.Instance.MakeWindow("敵をたおした！");
                yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        turnActions.Clear();
        commandOrder = 0;
    }

    private void UpdatePlayersStatusView()
    {
        playerStatusView.SetHpText(player.Status.Hp.ToString());
        playerStatusView.SetMpText(player.Status.Mp.ToString());
        buddyStatusView.SetHpText(buddy.Status.Hp.ToString());
        buddyStatusView.SetMpText(buddy.Status.Mp.ToString());
    }
}
