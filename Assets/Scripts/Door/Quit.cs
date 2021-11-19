using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public GameObject QPanel;
    void Start()
    {
        QPanel.SetActive(false);
    }
    void Update()
    {
        if(!QPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QPanel.gameObject.SetActive(true);
            }
            return;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
        {
            QPanel.gameObject.SetActive(false);
        }
    }
}
