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

    public ISkillAction MakeSkillAction(SkillMaster skillId)
    {
        ISkillAction action = null;
        switch(skillId)
        {
            case SkillMaster.Heal:
                action = new HealSkillAction();
                break;
            case SkillMaster.Cover:
                action = new CoverSkillAction();
                break;
            default:
                Debug.Log("No Such Skill");
                break;
        }
        return action;
    }
}
