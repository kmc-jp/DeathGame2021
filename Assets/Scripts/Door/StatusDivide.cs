using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDivide : MonoBehaviour
{
    public Text RestText;
    public int rest = 10;
        void Start()
    {
        RestText = GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<Text>();
    }


    void Update()
    {  //割り振り可能な残りステータスの表示
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            rest = System.Math.Max(rest - 1, 0);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rest = System.Math.Min(rest + 1, 10);
        }
        RestText.text = $"残り:{rest.ToString()}";

    }
//リセットボタン用関数 
    public void Rest_Reset()
    {
        rest = 10;
    }
}
