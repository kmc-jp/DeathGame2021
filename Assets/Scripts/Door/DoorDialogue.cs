using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDialogue : MonoBehaviour
{
    public GameObject panel;
    public GameObject window_stat;
    public GameObject Message;
    public MoveController moveController;
    private bool isMove;
    private bool isStay;
    private int textid = 0;
    void Start()
    {
       Message = GameObject.Find("Canvas/WindowMessage/Message");
       panel.SetActive(false);
       moveController = GameObject.Find("Player").GetComponent<MoveController>();
       window_stat.SetActive(false);
    }

    void Update()
    {
        Maine(textid);
        //メッセージが出ている間プレイヤーが動かないようにする
        if(panel.activeSelf)
        {
            moveController.PlayerSpeedfixed(0);
           GameObject.Find("Player").GetComponent<AnimationStateController>().isMove = false;
        }
        else 
        {
            moveController.PlayerSpeedfixed(2.0f);
            GameObject.Find("Player").GetComponent<AnimationStateController>().isMove = true;
        }
    }

    void OnCollisionStay2D(Collision2D collider2)
    {
        isStay = true;
    }
  void OnCollisionExit2D(Collision2D collide2)
  {
      panel.SetActive(false);
      isStay = false;
      textid = 0;
  }
  public void ChangeDoorText(int id)
    {
        Message.GetComponent<Text>().text = StringClass.SutefuriyaTexts[id];
    }
  void Maine(int n)
  {
        switch(n)
        {
            case 0:
            if(Input.GetKeyUp(KeyCode.Z) && isStay)
            {
                panel.SetActive(true);
                ChangeDoorText(n + 1);
                textid += 1;
            }
            break;

            case 5:
            window_stat.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Z))
            {
                window_stat.SetActive(false);
                ChangeDoorText(n + 1);
                textid += 1;
            }
            break;

            case 7:
            panel.SetActive(false);
            textid = 0;
            break;

            default:
            if(Input.GetKeyUp(KeyCode.Z) && panel.activeSelf)
            {
                ChangeDoorText(n + 1);
                textid += 1;
            }
             break;
          }

  }
}
