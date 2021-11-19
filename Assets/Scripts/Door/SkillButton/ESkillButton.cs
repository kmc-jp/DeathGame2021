using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESkillButton : MonoBehaviour
{
    private bool ischeck_select = false;
    public Text ebtext;
    private int skillcount;
    private List<SkillMaster> skillMasters = new List<SkillMaster>(){
        SkillMaster.EnhancedAttackP
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
           ebtext.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);//赤
           ischeck_select = true;
           skillcount = 1;
        }
        else if(ischeck_select)
        {
            ebtext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);//黒
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
