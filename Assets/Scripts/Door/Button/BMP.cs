using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BMP : MonoBehaviour
{
 public Text Mp_Text; 
 private int status_mp = 0;
 public Button button_mp;
 private string rest;
 public GameObject mp_status_panel;

 public GameObject Status_Rest;
 void Start()
{
   button_mp = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/MP").GetComponent<Button>();
   Mp_Text = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/MP/Counter").GetComponent<Text>();
   mp_status_panel = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/MP/StatusMPPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Rest");
}

public void MPbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "MPに関するステータス";
        if(status_mp==0)
        {
           Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(false);
        }
        else
        {
           Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(true);
        }

            rest = Status_Rest.GetComponent<Text>().text;
            if(Input.GetKeyUp(KeyCode.LeftArrow) && status_mp != 0)
            {
                GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(false);
                this.status_mp = System.Math.Max(status_mp - 1, 0);
            }

            if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
            {
                status_mp = System.Math.Min(status_mp + 1, 10);
                GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(true);
            }
            Mp_Text.text = $"{status_mp.ToString()}";
            
    }
}