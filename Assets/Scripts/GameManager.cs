using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
