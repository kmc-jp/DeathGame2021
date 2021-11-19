using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
    public GameObject IsExitPanel;
    // Start is called before the first frame update
    void OnCollisionStay2D(Collision2D collision)
    {
        IsExitPanel.SetActive(true);        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Application.Quit();                           //実際に動かしているとき
            //UnityEditor.EditorApplication.isPlaying = false;//Unity上で動かしているとき
            Debug.Log("ゲームは終了しました");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        IsExitPanel.SetActive(false);
    }

}
