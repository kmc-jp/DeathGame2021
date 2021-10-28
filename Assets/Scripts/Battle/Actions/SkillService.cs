using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillMaster
{
    Heal,
}

public class SkillService : SingletonMonoBehaviour<SkillService>
{
    public readonly Dictionary<SkillMaster, string> SkillNameMaster = new Dictionary<SkillMaster, string>(){
        { SkillMaster.Heal, "回復呪文"},
    };

    public readonly Dictionary<SkillMaster, Type> SkillTypeMaster = new Dictionary<SkillMaster, Type>(){
        { SkillMaster.Heal, typeof(HealSkillAction)},
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
            default:
                Debug.Log("No Such Skill");
                break;
        }
        return action;
    }
}
