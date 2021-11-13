using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    [SerializeField]
    private DisplayStatus playerStatusView;
    
    [SerializeField]
    private DisplayStatus buddyStatusView;
    private Player player;
    private Player buddy;

    public List<Player> playerList;
    
    [SerializeField]
    private GameObject topPanel;

    private List<IEnemy> enemyList;

    [SerializeField]
    private GameObject skillButtonField;

    [SerializeField]
    private GameObject audioManager;
    private List<AudioSource> sounds;

    // そのターンに実行されるアクション
    private List<ITurnAction> turnActions;

    // 0なら主人公 1なら相棒
    private int commandOrder;

    private Tween commandSelectTween;
    
    void Start()
    {
        Image psv = playerStatusView.StatusPanel;
        Image bsv = buddyStatusView.StatusPanel;
        player = new Player(PlayerPrefs.GetString("PLAYER_NAME"),
                new Status(500, 100, 20, 10, 10),
                psv,
                new List<SkillMaster>(){ SkillMaster.Heal, SkillMaster.Cover }
                );
        buddy = new Player("相棒",
                new Status(350, 300, 20, 10, 10),
                bsv,
                new List<SkillMaster>(){ SkillMaster.Heal, SkillMaster.Cover }
                );
        playerList = new List<Player>();
        playerList.Add(player);
        playerList.Add(buddy);
        enemyList = new List<IEnemy>();
        int stage = 0;
        List<GameObject> enemys = StageMaster.GetEnemyObjects(stage);
        foreach (var e in enemys)
        {
            GameObject enemyObj = (GameObject)Instantiate(
                e, 
                topPanel.transform);
            enemyList.Add(enemyObj.GetComponent<EnemyBehaviour>().EnemyCore);
        }
        turnActions = new List<ITurnAction>();
        commandOrder = 0;
        sounds = audioManager.GetComponents<AudioSource>().ToList();

        UpdatePlayersStatusView();
        PlayCommandSelectEffect(commandOrder);
    }

    public void AttackButton()
    {
        Actor actor = playerList[commandOrder];
        PlayButtonSE();
        MakeTargetButton(actor, SkillMaster.None, true);
    }

    public void SkillButton()
    {
        ClearSkillPanel();
        PlayButtonSE();
        Player actor = playerList[commandOrder];
        List<SkillMaster> skills = actor.Skills;
        for (int i = 0; i < skills.Count; i++ )
        {
            SkillMaster s = skills[i];
            Button button = CreateMiddleButton(SkillService.Instance.SkillNameMaster[s], i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    PlayButtonSE();
                    ClearSkillPanel();
                    MakeTargetButton(actor, s, false);
                })
                .AddTo(this);
        }
    }
    public void GuardButton()
    {
        PlayButtonSE();
        IActor actor = playerList[commandOrder];
        turnActions.Add(new GuardAction(actor, false));
        this.AddAction(new GuardAction(actor, true));
    }

    private void AddAction(ITurnAction action)
    {
        this.turnActions.Add(action);
        ClearSkillPanel();
        if (commandOrder >= 1) 
        {
            Execute();
            return;
        }
        commandOrder ++;
        PlayCommandSelectEffect(commandOrder);
    }

    private void AddAction(List<ITurnAction> actions)
    {
        this.turnActions.AddRange(actions);
        ClearSkillPanel();
        if (commandOrder >= 1) 
        {
            Execute();
            return;
        }
        commandOrder ++;
        PlayCommandSelectEffect(commandOrder);
    }

    private void Execute()
    {
        enemyList.ForEach((e) =>
        {
            turnActions.Add(e.Action());
        });
        StartCoroutine(ExecuteCore());
    }

    private IEnumerator ExecuteCore()
    {
        StopCommandSelectEffect();
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
            if (a.Exec())
            {
                yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
            }
            UpdatePlayersStatusView();

            bool clear = true;
            foreach (var e in enemyList) { clear &= e.IsDead; }
            if (clear) 
            {
                // TODO: 終わったり次にいったりする処理書く
                MessageWindow.Instance.MakeWindow("敵をたおした！");
                yield return MessageWindow.Instance.CloseButton.OnClickAsObservable().First().ToYieldInstruction();
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("Door");
                yield break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        turnActions.Clear();
        commandOrder = 0;
        PlayCommandSelectEffect(commandOrder);
    }

    private void MakeTargetButton(IActor actor, SkillMaster skill, bool isToEnemy)
    {
        ClearSkillPanel();
        List<IActor> targets = new List<IActor>();
        if (isToEnemy)  targets = enemyList.Cast<IActor>().ToList();
            else targets = playerList.Cast<IActor>().ToList();
        
        for (int i = 0; i < targets.Count; i++)
        {
            IActor t = targets[i];
            Button button = CreateMiddleButton(t.Name, i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    PlayButtonSE();
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

    private void PlayCommandSelectEffect(int order)
    {
        StopCommandSelectEffect();
        commandSelectTween = playerList[order].SelectCommandEffect();
    }

    private void StopCommandSelectEffect()
    {
        if (commandSelectTween != null) 
        {
            commandSelectTween.Restart();
            commandSelectTween.Kill();
        }
    }

    public void PlayButtonSE()
    {
        sounds[0].PlayOneShot(sounds[0].clip);
    }

    public void PlayDamageSE()
    {
        sounds[1].PlayOneShot(sounds[1].clip);
    }
}
