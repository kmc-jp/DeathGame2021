using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HPButton : MonoBehaviour
{
 public Text Hp_Text; 
 public Button button_hp;
 public GameObject hp_status_panel;
 public GameObject Status_Rest;
 private int status_hp = 0;
 private string rest;

private EventSystem ev;

private void Awake()
{
    ev = EventSystem.current;
    ev.firstSelectedGameObject = GameObject.Find("Canvas/StatusPanel/Status_Select/HP");
}
void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
   Hp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/Counter").GetComponent<Text>();
   hp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/StatusHPPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel/Status_Rest");
}

public void HPbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "HPに関するステータス";
        if(status_hp==0)
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(false);
        }
        else
        {
            Status_Rest.GetComponent<StefuriExcess>().Setstop_count(true);
        }
        rest = Status_Rest.GetComponent<Text>().text;
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_hp != 0)
        {
            GameObject.Find($"Canvas/StatusPanel/Status_Select/HP/StatusHPPanel/{status_hp}").SetActive(false);
            status_hp = System.Math.Max(status_hp - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
        {
            status_hp = System.Math.Min(status_hp + 1, 10);
            GameObject.Find($"Canvas/StatusPanel/Status_Select/HP/StatusHPPanel/{status_hp}").SetActive(true);
        }
        Hp_Text.text = $"{status_hp.ToString()}";
        
    }

//リセットボタン用関数    
  public void HP_Reset()
 {
     status_hp = 0;
 }

}
