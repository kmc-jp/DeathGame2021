using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSkillButton : MonoBehaviour
{
    private bool ischeck_select = false;
    public Text bbtext;
    private int skillcount;
    private List<SkillMaster> skillMasters = new List<SkillMaster>(){
        SkillMaster.AtkBuff, SkillMaster.HealBuff
    };
    public int Getskillcount()
    {
        return skillcount;
    }

    public void Setselecttrue(bool value)
    {
        ischeck_select = value;
    }
    public void SkillSwitch()
    {
        if(!ischeck_select)
        {
           bbtext.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
           ischeck_select = true;
           skillcount = 1;
        }
        else if(ischeck_select)
        {
            bbtext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            ischeck_select = false;
            skillcount = 0;
        }
        
    }

    public List<SkillMaster> GetSkillList()
    {
        if(ischeck_select)
        {
            return skillMasters;
        }
        
        return new List<SkillMaster>();
    }
}