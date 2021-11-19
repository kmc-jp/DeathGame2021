using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AGIButton : MonoBehaviour
{
 public Text Agi_Text; 
 public Button button_agi;
 public GameObject agi_status_panel;
 public GameObject Status_Rest;
 private int status_agi = 0;
 private string rest;
 
void Start()
{
   button_agi = GameObject.Find("Canvas/StatusPanel/Status_Select/AGI").GetComponent<Button>();
   Agi_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/AGI/Counter").GetComponent<Text>();
   agi_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/AGI/StatusAGIPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel/Status_Rest");
}

public void AGIbuttonOperation()//選択されているとき
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "素早さに関するステータス";
        if(status_agi==0)
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(false);
        }
        else
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(true);
        }
        rest = Status_Rest.GetComponent<Text>().text;
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_agi != 0)
        {
            GameObject.Find($"Canvas/StatusPanel/Status_Select/AGI/StatusAGIPanel/{status_agi}").SetActive(false);
            status_agi = System.Math.Max(status_agi - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
        {
            status_agi = System.Math.Min(status_agi + 1, 5);
            GameObject.Find($"Canvas/StatusPanel/Status_Select/AGI/StatusAGIPanel/{status_agi}").SetActive(true);
        }
        Agi_Text.text = $"{status_agi.ToString()}";
        
    }
}

