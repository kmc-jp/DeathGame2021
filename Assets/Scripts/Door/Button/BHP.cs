using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BHP : MonoBehaviour
{
 public Text Hp_Text; 
 public Button button_hp;
 public GameObject hp_status_panel;
 public GameObject Status_Rest;
 private int status_hp = 0;
 private string rest;

//private EventSystem ev;
void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/BHP").GetComponent<Button>();
   Hp_Text = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/BHP/BCounter").GetComponent<Text>();
   hp_status_panel = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Select/BHP/StatusBHPPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel(buddy)/Status_Rest");
}

public void BHPbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "HPに関するステータス";
        if(status_hp==0)
        {
            Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(false);
        }
        else
        {
            Status_Rest.GetComponent<BuddyStefuriExcess>().Setstop_count(true);
        }
        rest = Status_Rest.GetComponent<Text>().text;
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_hp != 0)
        {
            GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/BHP/StatusBHPPanel/{status_hp}").SetActive(false);
            status_hp = System.Math.Max(status_hp - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
        {
            status_hp = System.Math.Min(status_hp + 1, 10);
            GameObject.Find($"Canvas/StatusPanel(buddy)/Status_Select/BHP/StatusBHPPanel/{status_hp}").SetActive(true);
        }
        Hp_Text.text = $"{status_hp.ToString()}";
        
    }

}
