using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StefuriExcess : MonoBehaviour
{
    public Text RestText;
    private int rest = 10;
    private bool stop_count = true;
    
    void Start()
    {
        RestText = GameObject.Find("Canvas/StatusPanel/Status_Rest").GetComponent<Text>();
    }

    public int GetRest()
    {
        return rest;
    }

    public void Setstop_count(bool value)
    {
        this.stop_count = value;
    }
    public void RestOperation()
    {  //割り振り可能な残りステータスの表示
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            rest = System.Math.Max(rest - 1, 0);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) && stop_count)
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
