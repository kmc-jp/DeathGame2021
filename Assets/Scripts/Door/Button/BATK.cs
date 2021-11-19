using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BATK : MonoBehaviour
{
 public Text Atk_Text; 
 public Button button_atk;
 public GameObject atk_status_panel;
 public GameObject Status_Rest;
 public int status_atk = 0;
 private string rest;
 
void Start()
{
   button_atk = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/ATK").GetComponent<Button>();
   Atk_Text = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/ATK/Counter").GetComponent<Text>();
   atk_status_panel = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/ATK/StatusATKPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Rest");
}

public void ATKbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "攻撃に関するステータス";
        if(status_atk==0)
        {
            Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(false);
        }
        else
        {
            Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(true);
        }
        rest = Status_Rest.GetComponent<Text>().text;
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_atk != 0)
        {
            GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/ATK/StatusATKPanel/{status_atk}").SetActive(false);
            status_atk = System.Math.Max(status_atk - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
        {
            status_atk = System.Math.Min(status_atk + 1, 10);
            GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/ATK/StatusATKPanel/{status_atk}").SetActive(true);
        }
        Atk_Text.text = $"{status_atk.ToString()}";
        
    }
}
