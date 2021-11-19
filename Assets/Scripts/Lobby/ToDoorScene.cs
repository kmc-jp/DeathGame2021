using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToDoorScene : MonoBehaviour
{

    public GameObject Buddybody;
    public GameObject ToDoorWindow;
    public GameObject Messagge;

    void Start()
    {
        ToDoorWindow.SetActive(false);
    }

    
    void OnCollisionStay2D(Collision2D collision)
    {
        if(Buddybody.activeSelf)
        {
           ToDoorWindow.SetActive(true);
            Messagge.GetComponent<Text>().text = "魔法の力が強く先に進むことができない";
        }
        else
        {
            ToDoorWindow.SetActive(true);
            Messagge.GetComponent<Text>().text = "このまま進んでよろしいですか\n(進む場合はzキーを押してください)";
            if(Input.GetKey(KeyCode.Z))
            {
                FadeManager.Instance.LoadScene("Door", 1.0f);
            }
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        ToDoorWindow.SetActive(false);
    }
}
