using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject Panel;
    GameObject IsExitPanel;
    // Start is called before the first frame update
    void Start()
    {
       GameObject.Find("Panel").SetActive(false);
       GameObject.Find("IsExitPanel").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
