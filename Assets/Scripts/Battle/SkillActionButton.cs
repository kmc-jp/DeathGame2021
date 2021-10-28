using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActionButton : MonoBehaviour
{
    void Start()
    {

    }

    public void OnClick()
    {
        // 回復で仮組
        Actor actor = BattleManager.Instance.players[BattleManager.Instance.CommandOrder];
        BattleManager.Instance.AddAction(new HealSkillAction(actor, actor));
    }
}
