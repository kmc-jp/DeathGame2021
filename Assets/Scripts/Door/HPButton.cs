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

 private bool isSelect = true;

void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
    button_hp.Select();
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
            if(Input.GetKeyUp(KeyCode.RightArrow) && rest != "残り:0")
            {
                status_hp = System.Math.Min(status_hp + 1, 10);
            }
            Hp_Text.text = $"{status_hp.ToString()}";
        }

    }
}
