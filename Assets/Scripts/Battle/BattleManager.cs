using System.Collections;
using System.Collections.Generic;
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
    private List<EnemyBehaviour> enemyList = new List<EnemyBehaviour>();
    private Enemy enemy;

    private List<ITurnAction> turnActions;
    
    void Start()
    {
        player = new Player("主人公", new Status(500, 100, 20, 10, 10));
        buddy = new Player("相棒", new Status(350, 300, 20, 10, 10));
        players = new List<Player>();
        players.Add(player);
        players.Add(buddy);
        enemy = enemyList[0].EnemyCore;
        turnActions = new List<ITurnAction>();
        UpdatePlayersStatusView();
    }

    public void AttackButton()
    {
        Actor actor = players[turnActions.Count];
        turnActions.Add(new AttackAction(actor, enemy));
        if (turnActions.Count >= 2) Execute();
    }

    public void Execute()
    {
        enemyList.ForEach((e) =>
        {
            turnActions.Add(e.Action());
        });
        // agi降順にソート
        turnActions.Sort((a, b) => a.Actor.Status.Agi - b.Actor.Status.Agi);
        StartCoroutine(ExecuteCore());
    }

    private IEnumerator ExecuteCore()
    {
        foreach (var a in turnActions)
        {
            a.Prepare();
            yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
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
    }

    private void UpdatePlayersStatusView()
    {
        playerStatusView.SetHpText(player.Status.Hp.ToString());
        playerStatusView.SetMpText(player.Status.Mp.ToString());
        buddyStatusView.SetHpText(buddy.Status.Hp.ToString());
        buddyStatusView.SetMpText(buddy.Status.Mp.ToString());
    }
}
