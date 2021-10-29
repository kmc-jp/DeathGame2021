using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillMaster
{
    Heal,
    Cover,
}

public class SkillService : SingletonMonoBehaviour<SkillService>
{
    public readonly Dictionary<SkillMaster, string> SkillNameMaster = new Dictionary<SkillMaster, string>(){
        { SkillMaster.Heal, "回復呪文"},
        { SkillMaster.Cover, "身代わり"},
    };

    public readonly Dictionary<SkillMaster, Type> SkillTypeMaster = new Dictionary<SkillMaster, Type>(){
        { SkillMaster.Heal, typeof(HealSkillAction)},
        { SkillMaster.Cover, typeof(CoverSkillAction)},
    };
    
    void Start()
    {
        
    }

    public List<ITurnAction> MakeSkillAction(SkillMaster skillId, Actor actor, Actor target)
    {
        List<ITurnAction> actions = new List<ITurnAction>();
        switch(skillId)
        {
            case SkillMaster.Heal:
                actions.Add(new HealSkillAction(actor, target));
                break;
            case SkillMaster.Cover:
                actions.Add(new CoverSkillAction(actor, target, false));
                actions.Add(new CoverSkillAction(actor, target, true));
                break;
            default:
                Debug.Log("No Such Skill");
                break;
        }
        return actions;
    }
}
