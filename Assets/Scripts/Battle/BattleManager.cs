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

    public List<Player> playerList;
    
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
        // TODO: MonoBehaviourなのにnewしてて怒られてる
        player = new Player("主人公", new Status(500, 100, 20, 10, 10), psv);
        buddy = new Player("相棒", new Status(350, 300, 20, 10, 10), bsv);
        playerList = new List<Player>();
        playerList.Add(player);
        playerList.Add(buddy);
        turnActions = new List<ITurnAction>();
        UpdatePlayersStatusView();
    }

    public void AttackButton()
    {
        enemy = enemyList[0];
        Actor actor = playerList[CommandOrder];
        this.AddAction(new AttackAction(actor, enemy));
    }

    public void SkillButton()
    {
        Player actor = playerList[CommandOrder];
        List<SkillMaster> skills = actor.Skills;
        for (int i = 0; i < skills.Count; i++ )
        {
            SkillMaster s = skills[i];
            Button button = CreateMiddleButton(SkillService.Instance.SkillNameMaster[s], i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    ClearSkillPanel();
                    MakeTargetButton(actor, s, false);
                })
                .AddTo(this);
        }
    }

    public void MakeTargetButton(Actor actor, SkillMaster skill, bool isToEnemy)
    {
        List<Actor> targets = new List<Actor>();
        if (isToEnemy)  targets = enemyList.Cast<Actor>().ToList();
            else targets = playerList.Cast<Actor>().ToList();
        
        for (int i = 0; i < targets.Count; i++)
        {
            Actor t = targets[i];
            Button button = CreateMiddleButton(t.Name, i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    List<ITurnAction> actions = SkillService.Instance.MakeSkillAction(skill, actor, t);
                    this.AddAction(actions);
                })
                .AddTo(this);
        }
    }

    private Button CreateMiddleButton(string label, int idx)
    {
        GameObject buttonObj = (GameObject)Resources.Load("Prefabs/SkillButton");
        GameObject skillButton = (GameObject)Instantiate(
            buttonObj, 
            skillButtonField.transform);
        skillButton.GetComponent<RectTransform>().localPosition += new Vector3(0.0f, -50.0f * idx, 0.0f);
        Button buttonComponent = skillButton.GetComponent<Button>();
        SkillActionButton skillActionButton = skillButton.GetComponent<SkillActionButton>();
        skillActionButton.SetLabel(label);
        return buttonComponent;
    }

    public void GuardButton()
    {
        Actor actor = playerList[CommandOrder];
        turnActions.Add(new GuardAction(actor, false));
        this.AddAction(new GuardAction(actor, true));
    }

    public void AddAction(ITurnAction action)
    {
        this.turnActions.Add(action);
        if (CommandOrder >= 1) Execute();
        CommandOrder ++;
        ClearSkillPanel();
    }

    public void AddAction(List<ITurnAction> actions)
    {
        this.turnActions.AddRange(actions);
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
        // priority降順 agi降順にソート
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
