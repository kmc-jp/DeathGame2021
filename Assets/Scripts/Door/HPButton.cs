using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPButton : MonoBehaviour
{
 public Text Hp_Text; 
 public Button button_hp;
 public GameObject hp_status_panel;
 private int status_hp = 0;
 private string rest;
 //private bool ischeckb;
void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
   button_hp.Select();
   Hp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/Counter").GetComponent<Text>();
   hp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/StatusHPPanel");
}

public void HPbuttonOperation()
    {
        if(status_hp==0)
        {
            GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<StatusDivide>().Setstop_count(false);
        }
        else
        {
            GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<StatusDivide>().Setstop_count(true);
        }
        rest = GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<Text>().text;
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
