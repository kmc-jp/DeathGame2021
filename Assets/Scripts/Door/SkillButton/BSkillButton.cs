using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSkillButton : MonoBehaviour
{
    private bool ischeck_select = false;
    public Text bbtext;
    private int skillcount;

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
           skillcount = 0;
        }
        else if(ischeck_select)
        {
            bbtext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            ischeck_select = false;
            skillcount = 0;
        }
        
    }
}