using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillMaster
{
    Heal,
}

public class SkillService : SingletonMonoBehaviour<SkillService>
{
    
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
