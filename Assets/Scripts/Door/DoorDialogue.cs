using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorDialogue : MonoBehaviour
{
    public GameObject panel;
    public GameObject window_stat;//主人公のステータス画面
    public GameObject Bwindow_stat;//相棒のステータス画面
    public GameObject window_skil;//わざ画面
    public GameObject Message;
    public MoveController moveController;
    private bool isStay;
    private bool Select_Button_Flag = false;
    private int textid = 0;
    private EventSystem ev;

    [SerializeField]
    private GameObject HpbP;
    [SerializeField]
    private GameObject HpbB;
    void Start()
    {
       Message = GameObject.Find("Canvas/WindowMessage/Message");
       panel.SetActive(false);
       moveController = GameObject.Find("Player").GetComponent<MoveController>();
       window_stat.SetActive(false);
       window_skil.SetActive(false);
       Bwindow_stat.SetActive(false);
    }

    void Update()
    {　 //表示メッセージを更新
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
        Message.GetComponent<Text>().text = DoorStringClass.SutefuriyaTexts[id];
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

            case 2:
            if(Input.GetKeyUp(KeyCode.Alpha1))//ステータス割り振りへ
            {
                ChangeDoorText(n + 1);
                textid += 1;
            }
            else if(Input.GetKeyUp(KeyCode.Alpha2))//わざ決定へ
            {
                ChangeDoorText(8);
                textid = 8;
            }
            break;
            

            case 3://誰にステータスを振るか
            if(Input.GetKeyUp(KeyCode.Alpha1))//主人公へ
            {
                ChangeDoorText(n + 1);
                textid += 1;
            }
            else if(Input.GetKeyUp(KeyCode.Alpha2))//相棒へ
            {
                ChangeDoorText(10);
                textid = 10;
            }
            Select_Button_Flag = true;
            break;

            case 5://主人公のステータス画面を表示
            if(Select_Button_Flag)
            {
                EventSystem.current.SetSelectedGameObject (HpbP);
                Select_Button_Flag = false;
            }
            window_stat.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Z))
            {
                window_stat.SetActive(false);
                ChangeDoorText(n + 1);
                textid += 1;
            }
            break;

            case 7://ステ振り屋との会話を抜ける
            panel.SetActive(false);
            textid = 0;
            break;

            case 9://わざ画面を表示
            window_skil.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Z))
            {
                window_skil.SetActive(false);
                ChangeDoorText(6);
                textid = 6;
            }
            break;

            case 11://相棒のステータス画面を表示
            if(Select_Button_Flag)
            {
                EventSystem.current.SetSelectedGameObject (HpbB);
                Select_Button_Flag = false;
            }
            Bwindow_stat.SetActive(true);
            if(Input.GetKeyUp(KeyCode.Z))
            {
                Bwindow_stat.SetActive(false);
                ChangeDoorText(6);
                textid = 6;
            }
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
