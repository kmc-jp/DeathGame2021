using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCounter : MonoBehaviour
{
    private int sumskillcount;

    private bool reversecheck = false;
    void Update()
    {
        sumskillcount = this.GetComponent<ESkillButton>().Getskillcount() + 
                        this.GetComponent<HSkillButton>().Getskillcount() +
                        this.GetComponent<SSkillButton>().Getskillcount() +
                        this.GetComponent<BSkillButton>().Getskillcount();

        if(sumskillcount == 2)
        {
            this.GetComponent<ESkillButton>().Setselecttrue(true);
            this.GetComponent<HSkillButton>().Setselecttrue(true);
            this.GetComponent<SSkillButton>().Setselecttrue(true);
            this.GetComponent<BSkillButton>().Setselecttrue(true);
            reversecheck = true;
        }
        else if(reversecheck)
        {
            if(this.GetComponent<ESkillButton>().Getskillcount() == 0)
            {
                this.GetComponent<ESkillButton>().Setselecttrue(false);
            }

            if(this.GetComponent<HSkillButton>().Getskillcount() == 0)
            {
                this.GetComponent<HSkillButton>().Setselecttrue(false);
            }

            if(this.GetComponent<SSkillButton>().Getskillcount() == 0)
            {
                this.GetComponent<SSkillButton>().Setselecttrue(false);
            }

            if(this.GetComponent<BSkillButton>().Getskillcount() == 0)
            {
                this.GetComponent<BSkillButton>().Setselecttrue(false);
            }

            reversecheck = false;
        }
        
    }
}
