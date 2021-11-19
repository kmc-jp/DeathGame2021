using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entry_Option : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Dialog;
    
    void OnCollisionStay2D(Collision2D collison)
    {
        Panel.SetActive(true);
        Dialog.GetComponent<Text>().text = StringClass.Text4;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Panel.SetActive(false);
    }
}