using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPButton : MonoBehaviour
{
 public Text Hp_Text; 
 public Button button_hp;
 public GameObject hp_status_panel;
 public StatusDivide statusDivide;
 private int status_hp = 0;
 //private bool ischeckb;
void Start()
{
   statusDivide = new StatusDivide();
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
   button_hp.Select();
   Hp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/Counter").GetComponent<Text>();
   hp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/StatusHPPanel");
}

public void HPbuttonOperation()
    {
        int rest = statusDivide.GetRest();
        if(Input.GetKeyUp(KeyCode.LeftArrow) && status_hp != 0)
        {
            GameObject.Find($"Canvas/StatusPanel/Status_Select/HP/StatusHPPanel/{status_hp}").SetActive(false);
            status_hp = System.Math.Max(status_hp - 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && rest != 0) 
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
