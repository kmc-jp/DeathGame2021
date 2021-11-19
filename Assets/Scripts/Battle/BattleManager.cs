using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
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
    
    [SerializeField] bool debugMode;
    [SerializeField] int Floor;
    
    readonly List<Func<UniTask>> onTurnEnd = new List<Func<UniTask>>();
    public IDisposable OnTurnEnd(Func<UniTask> task)
    {
        onTurnEnd.Add(task);
        return Disposable.Create(() => onTurnEnd.Remove(task));
    }
    
    void Start()
    {
        Image psv = playerStatusView.StatusPanel;
        Image bsv = buddyStatusView.StatusPanel;
        player = new Player(
                PlayerId.Player,
                PrefsUtil.GetPlayerName(),
                new Status(500, 100, 100, 10, 10),
                psv,
                new List<SkillMaster>(){ 
                    SkillMaster.Heal,
                    SkillMaster.Cover,
                    SkillMaster.EnhancedAttack,
                    SkillMaster.HighHeal
                    }
                );
        buddy = new Player(
                PlayerId.Buddy,
                "相棒",
                new Status(35, 300, 150, 10, 10),
                bsv,
                new List<SkillMaster>(){ SkillMaster.Heal, SkillMaster.Cover, SkillMaster.EnhancedAttack }
                );
        playerList = new List<Player>();
        playerList.Add(player);
        playerList.Add(buddy);
        enemyList = new List<IEnemy>();
        
        if (!debugMode) Floor = PrefsUtil.GetStageProgress();
        List<GameObject> enemys = StageMaster.GetEnemyObjects(Floor);
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
        
        string message = String.Join(" と ", enemyList.Select(e => e.Name)) + " があらわれた！";
        MessageWindow.Instance.MakeWindow(message);
        UpdatePlayersStatusView();
        PlayCommandSelectEffect(commandOrder);
    }

    public void AttackButton()
    {
        Actor actor = playerList[commandOrder];
        PlayButtonSE();
        MakeTargetButton(actor, SkillMaster.NormalAttack, true);
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
            SkillInfo info = SkillService.SkillInfoMaster[s];
            Button button = CreateMiddleButton(info.Name, i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    PlayButtonSE();
                    ClearSkillPanel();
                    MakeTargetButton(actor, s, info.IsToEnemy);
                })
                .AddTo(this);
        }
    }
    public void GuardButton()
    {
        PlayButtonSE();
        IActor actor = playerList[commandOrder];
        this.AddAction(new GuardAction(actor));
    }

    public void EscapeButton()
    {
        PlayButtonSE();
        MessageWindow.Instance.MakeWindow("敵から逃げ切った");
        MessageWindow.Instance.CloseButton.OnClickAsObservable()
            .First()
            .Subscribe(_ => SceneManager.LoadScene("Door"))
            .AddTo(this);
    }

    private void AddAction(ITurnAction action)
    {
        this.turnActions.Add(action);
        ClearSkillPanel();
        UpdateCommandOrder(commandOrder + 1);
    }

    private void AddAction(List<ITurnAction> actions)
    {
        this.turnActions.AddRange(actions);
        ClearSkillPanel();
        UpdateCommandOrder(commandOrder + 1);
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
                yield return MessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
            }

            yield return a.Exec().ToCoroutine();

            if (a is AttackAction
                || a is AttacksInARowAction
                || a is EnhancedAttackSkillAction
                || a is AttackToAllAction
                || a is FatalAttackAction)
            {
                a.Actor.Buffs.AttackRate = 1;
            }
            
            UpdatePlayersStatusView();

            bool clear = true;
            foreach (var e in enemyList) { clear &= e.IsDead; }
            if (clear) 
            {
                MessageWindow.Instance.MakeWindow("敵をたおした！");
                PrefsUtil.UpdateStageProgress();
                yield return MessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("Door");
                yield break;
            }
            bool defeat = playerList.Where(ally => !ally.IsDead).Count() == 0;
            if (defeat)
            {
                MessageWindow.Instance.MakeWindow("ぜんめつしてしまった");
                yield return MessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
                yield return new WaitForSeconds(0.3f);
                SceneManager.LoadScene("Door");
                yield break;
            }
        }
        foreach (var p in playerList)
        {
            p.Buffs.ProcessBuffs();
        }
        foreach (var e in enemyList)
        {
            e.Buffs.ProcessBuffs();
        }
        if (MessageWindow.Instance.MakeWindow())
        {
            yield return MessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
        }
        foreach (Func<UniTask> task in onTurnEnd)
        {
            yield return task?.Invoke().ToCoroutine();
        }
        yield return new WaitForSeconds(0.5f);
        turnActions.Clear();
        UpdateCommandOrder(0);
    }

    private void MakeTargetButton(IActor actor, SkillMaster skill, bool isToEnemy)
    {
        ClearSkillPanel();
        List<IActor> targets = new List<IActor>();
        if (isToEnemy)  targets = enemyList.Where(ally => !ally.IsDead).Cast<IActor>().ToList();
            else targets = playerList.Where(ally => !ally.IsDead).Cast<IActor>().ToList();
        
        for (int i = 0; i < targets.Count; i++)
        {
            IActor t = targets[i];
            Button button = CreateMiddleButton(t.Name, i);
            button.OnClickAsObservable()
                .First()
                .Subscribe(_ => 
                {
                    PlayButtonSE();
                    List<ITurnAction> actions = SkillService.MakeSkillAction(skill, actor, t);
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


    public void UpdatePlayersStatusView()
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

    private void UpdateCommandOrder(int _order)
    {
        if (_order >= 2) 
        {
            Execute();
            return;
        }
        if (playerList[_order].IsDead)
        {
            UpdateCommandOrder(_order + 1);
            return;
        }
        commandOrder = _order;
        PlayCommandSelectEffect(commandOrder);
    }
}
