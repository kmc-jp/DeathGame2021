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
void Start()
{
   button_mp = GameObject.Find("Canvas/StatusPanel/Status_Select/MP").GetComponent<Button>();
   Mp_Text = GameObject.Find("Canvas/StatusPanel/Status_Select/MP/Counter").GetComponent<Text>();
   mp_status_panel = GameObject.Find("Canvas/StatusPanel/Status_Select/MP/StatusMPPanel");
}
public void MPbuttonOperation()
    {   //このボタンが選択されているかどうかの判定(やり方は分かっていない)
            rest = GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<Text>().text;
            if(Input.GetKeyUp(KeyCode.LeftArrow) && status_mp != 0)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(false);
                status_mp = System.Math.Max(status_mp - 1, 0);
            }

            if(Input.GetKeyDown(KeyCode.RightArrow) && rest != "残り:0") 
            {
                status_mp = System.Math.Min(status_mp + 1, 10);
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{status_mp}").SetActive(true);
            }
            Mp_Text.text = $"{status_mp.ToString()}";
            
            //緑のパネル表示管理(やり方の質は悪い)
            /*for(int i=1;i<=status_mp;i++)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{i}").SetActive(true);
            }
            for(int i=status_mp + 1;i<=10;i++)
            {
                GameObject.Find($"Canvas/StatusPanel/Status_Select/MP/StatusMPPanel/{i}").SetActive(false);
            }*/
    }

//リセットボタン用関数    
  public void MP_Reset()
 {
     status_mp = 0;
     Mp_Text.text = $"{status_mp.ToString()}";
     GameObject.Find("Canvas/StatusPanel/Status_Select/MP").SetActive(false);
     //GameObject.Find("Canvas/StatusPanel/Status_Select/MP").SetActive(true);
 }

}



/*MP_Resetが動作したらあるboolを返しボタンオペの中に値やパネルを初期化するやつを仕込む。
直後bool値をまたひっくり返す*/