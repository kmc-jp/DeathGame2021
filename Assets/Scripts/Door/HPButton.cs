using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPButton : MonoBehaviour
{
 public Text Hp_Text; 
 private int status_hp;
 public Button button_hp;
 private string rest;
 public GameObject hp_value_panel;
 private bool isSelect = true;

void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
   button_hp.Select();
   hp_value_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/HP");
   hp_value_panel.transform.Find("1").gameObject.SetActive(false);
}
public void Update()
    {
        if(isSelect)
        {
            rest = GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<Text>().text;
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                status_hp = System.Math.Max(status_hp - 1, 0);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
            {
                status_hp = System.Math.Min(status_hp + 1, 10);
            }
            Hp_Text.text = $"{status_hp.ToString()}";
            PanelSet(status_hp);
            
        }
    }

 public void Hp_Reset()
 {
     status_hp = 0;
 }

 public void PanelSet(int n)
 {
     switch(n)
     {
        case 0:
        break;
        
        case 1:
        hp_value_panel.transform.Find("1").gameObject.SetActive(true);
        hp_value_panel = hp_value_panel.transform.Find("1").gameObject;
        break;

        default:
        hp_value_panel.transform.Find($"{n}").gameObject.SetActive(true);
        hp_value_panel = hp_value_panel.transform.Find($"{n}").gameObject;
        break;
     }

     

 }
}
