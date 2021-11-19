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
        if(!QPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            QPanel.SetActive(true);
        }

        if(QPanel.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            Application.Quit();
        }

        if(QPanel.activeSelf && (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape)))
        {
            QPanel.SetActive(false);
        }
    }
}
