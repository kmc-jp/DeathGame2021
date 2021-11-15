using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEFButton : MonoBehaviour
{
 public Text Def_Text; 
 public Button button_def;
 public GameObject def_status_panel;
 public GameObject Status_Rest;
 private int status_def = 0;
 private string rest;
 //private bool ischeckb;
void Start()
{
   button_def = GameObject.Find("Canvas/StatusPanel/Status_Select/DEF").GetComponent<Button>();
   Def_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/DEF/Counter").GetComponent<Text>();
   def_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/DEF/StatusDEFPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel/Status_Rest");
}

public void DEFbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "防御に関するステータス";
        if(status_def==0)
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(false);
        }
        else
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(true);
        }
        rest = Status_Rest.GetComponent<Text>().text;
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_def != 0)
        {
            GameObject.Find($"Canvas/StatusPanel/Status_Select/DEF/StatusDEFPanel/{status_def}").SetActive(false);
            status_def = System.Math.Max(status_def - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
        {
            status_def = System.Math.Min(status_def + 1, 10);
            GameObject.Find($"Canvas/StatusPanel/Status_Select/DEF/StatusDEFPanel/{status_def}").SetActive(true);
        }
        Def_Text.text = $"{status_def.ToString()}";
        
    }

//リセットボタン用関数    
  public void DEF_Reset()
 {
     status_def = 0;
 }

}
