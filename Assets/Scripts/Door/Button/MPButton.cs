using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPButton : MonoBehaviour
{
 public Text Mp_Text; 
 private int status_mp = 0;
 public Button button_mp;
 private string rest;
 public GameObject mp_status_panel;

 public GameObject Status_Rest;
 void Start()
{
   button_mp = GameObject.Find("Canvas/StatusPanel/Status_Select/MP").GetComponent<Button>();
   Mp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/MP/Counter").GetComponent<Text>();
   mp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/MP/StatusMPPanel");
   Status_Rest = GameObject.Find("Canvas/StatusPanel/Status_Rest");
}

public void MPbuttonOperation()
    {
        GameObject.Find("Canvas/WindowMessage/Message").GetComponent<Text>().text = "MPに関するステータス";
        if(status_mp==0)
        {
           Status_Rest.GetComponent<StatusDivide>().Setstop_count(false);
        }
        else
        {
           Status_Rest.GetComponent<StatusDivide>().Setstop_count(true);
        }

            rest = Status_Rest.GetComponent<Text>().text;
            if(Input.GetKeyUp(KeyCode.LeftArrow) && status_mp != 0)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(false);
                this.status_mp = System.Math.Max(status_mp - 1, 0);
            }

            if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
            {
                status_mp = System.Math.Min(status_mp + 1, 10);
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(true);
            }
            Mp_Text.text = $"{status_mp.ToString()}";
            
    }

//リセットボタン用関数    
  public void MP_Reset()
 {
      
     for(int i =1;i<=10;i++)
       {
            GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{i}").SetActive(false);
        }
     status_mp = 0;
     Mp_Text.text = $"{status_mp.ToString()}";
 }

}



/*MP_Resetが動作したらあるboolを返しボタンオペの中に値やパネルを初期化するやつを仕込む。
直後bool値をまたひっくり返す*/