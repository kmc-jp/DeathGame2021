using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject serifupanel;

    void Start()
    {
       serifupanel = GameObject.Find("Canvas/SerifuPanel");
       serifupanel .SetActive(false);
    }

    void OnCollisionStay2D(Collision2D collision2)
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            serifupanel.SetActive(true);
        }     
    }

    void OnCollisionExit2D(Collision2D collision2)
    {
        serifupanel.SetActive(false);
    }
}
