using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buddy : MonoBehaviour
{
    public GameObject MessageWindow;
    public GameObject Message;

    public GameObject Buddybody;
    public MoveController moveController;
    private bool isStay;
    private int textid = 0;

    void Start()
    {
       Message = GameObject.Find("Canvas/MessageWindow/Message");
       MessageWindow.SetActive(false);
       moveController = GameObject.Find("Player").GetComponent<MoveController>();
    }

    void Update()
    {　 //表示メッセージを更新
        Maine(textid);

        //メッセージが出ている間プレイヤーが動かないようにする
        if(MessageWindow.activeSelf)
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
      MessageWindow.SetActive(false);
      isStay = false;
      textid = 0;
  }
  public void ChangeBuddyText(int id)
    {
        Message.GetComponent<Text>().text = BuddyStringClass.Texts[id];
    }
  void Maine(int n)
  {
        switch(n)
        {
            case 0:
            if(Input.GetKeyUp(KeyCode.Z) && isStay)
            {
                MessageWindow.SetActive(true);
                ChangeBuddyText(n + 1);
                textid += 1;
            }
            break;

            case 9://相棒との会話を抜ける
            Buddybody.SetActive(false);
            MessageWindow.SetActive(false);
            textid = 0;
            break;

            default:
            if(Input.GetKeyUp(KeyCode.Z) && MessageWindow.activeSelf)
            {
                ChangeBuddyText(n + 1);
                textid += 1;
            }
             break;
          }

  }
}