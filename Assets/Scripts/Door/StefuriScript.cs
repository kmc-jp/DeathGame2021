using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StefuriScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject Message;
    public int textid = 4;
    void Start()
    {
       panel.SetActive(false);
       Message = GameObject.Find("Canvas/WindowMessage/Message");
    }
  void OnTriggerStay2D(Collider2D collider2)
  {
      if(Input.GetKeyUp(KeyCode.Z))
      {
        panel.SetActive(true);
        
      }
  }

  void OnTriggerExit2D(Collider2D collide2)
  {
      panel.SetActive(false);
  }
}
