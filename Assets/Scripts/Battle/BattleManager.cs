using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

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
    private List<Enemy> enemyList;
    private Enemy enemy;

    [SerializeField]
    private GameObject skillButtonField;

    private List<ITurnAction> turnActions;

    public int CommandOrder = 0;
    
    void Start()
    {
        Image psv = playerStatusView.StatusPanel;
        Image bsv = buddyStatusView.StatusPanel;
        player = new Player(PlayerPrefs.GetString("PLAYER_NAME"), new Status(500, 100, 20, 10, 10), psv);
        buddy = new Player("相棒", new Status(350, 300, 20, 10, 10), bsv);
        players = new List<Player>();
        players.Add(player);
        players.Add(buddy);
        turnActions = new List<ITurnAction>();
        UpdatePlayersStatusView();
    }

    public void AttackButton()
    {
        enemy = enemyList[0];
        Actor actor = players[CommandOrder];
        this.AddAction(new AttackAction(actor, enemy));
    }

    public void SkillButton()
    {
        // スキル一覧を表示する動作をつくる
        Player p = players[CommandOrder];
        List<SkillMaster> skills = p.Skills;
        for (int i = 0; i < skills.Count; i++ )
        {
            SkillMaster s = skills[i];
            GameObject buttonObj = (GameObject)Resources.Load("Prefabs/SkillButton");
            GameObject skillButton = (GameObject)Instantiate(
                buttonObj, 
                skillButtonField.transform);
            skillButton.GetComponent <RectTransform>().localPosition += new Vector3(0.0f, -50.0f * i, 0.0f);
            Button buttonComponent = skillButton.GetComponent<Button>();
            SkillActionButton skillActionButton = skillButton.GetComponent<SkillActionButton>();
            skillActionButton.SetLabel(SkillService.Instance.SkillNameMaster[s]);
            buttonComponent.OnClickAsObservable()
                .First()
                .Select(_ => s)
                .Subscribe(id => 
                {
                    ISkillAction action = SkillService.Instance.MakeSkillAction(s);
                    action.Actor = p;
                    action.Target = p;
                    this.AddAction(action);
                })
                .AddTo(this);
        }
    }

    public void GuardButton()
    {
        Actor actor = players[CommandOrder];
        turnActions.Add(new GuardAction(actor, false, 1));
        this.AddAction(new GuardAction(actor, true, -1));
    }

    public void AddAction(ITurnAction action)
    {
        this.turnActions.Add(action);
        if (CommandOrder >= 1) Execute();
        CommandOrder ++;
        ClearSkillPanel();
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
            foreach (var e in enemyList) { clear &= e.IsDead; }
            if (clear) 
            {
                MessageWindow.Instance.MakeWindow("敵をたおした！");
                yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        turnActions.Clear();
        CommandOrder = 0;
    }

    private void UpdatePlayersStatusView()
    {
        playerStatusView.SetHpText(player.Status.Hp.ToString());
        playerStatusView.SetMpText(player.Status.Mp.ToString());
        buddyStatusView.SetHpText(buddy.Status.Hp.ToString());
        buddyStatusView.SetMpText(buddy.Status.Mp.ToString());
    }

    private void ClearSkillPanel()
    {
        foreach (Transform t in skillButtonField.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
    }
}
