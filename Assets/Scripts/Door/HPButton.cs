using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPButton : MonoBehaviour
{
 public Text Hp_Text; 
 private int status_hp = 0;
 public Button button_hp;
 private string rest;
 public GameObject hp_status_panel;
 private bool isSelect = true;

void Start()
{
   button_hp = GameObject.Find("Canvas/StatusPanel/Status_Select/HP").GetComponent<Button>();
   button_hp.Select();
   Hp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/Status_Hp_Count").GetComponent<Text>();
   hp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/HP/hp_status_panel");
}
public void UpdateSelected()
    {   //このボタンが選択されているかどうかの判定(やり方は分かっていない)
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
            
            //緑のパネル表示を管理するはずだった(入れると上の入力値がバグるので一旦保留)
            /*for(int i=1;i<=status_hp;i++)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/HP/hp_status_panel/{i}").SetActive(true);
            }*/
            /*for(int i=status_hp + 1;i<=10;i++)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/HP/hp_status_panel/{i}").SetActive(false);
            }*/
        }
    }

//リセットボタン用関数    
  public void Hp_Reset()
 {
     status_hp = 0;
 }

}
