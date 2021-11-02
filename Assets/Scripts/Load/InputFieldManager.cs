using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class InputFieldManager : MonoBehaviour
{
    //InputFieldを格納するための変数
    public InputField inputField;
    public GameObject InputField;
    public GameObject messageText;
    public GameObject enterButton;
    public GameObject backMessageButon;
    private string username;

    public GameObject backTitleButton;
 
    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        InputField = GameObject.Find("InputField");
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        messageText = GameObject.Find("Canvas/Panel/Text");
        enterButton.SetActive(false);
        backMessageButon.SetActive(false);
    }
 
 
    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        username = inputField.text;
        if(Input.GetKeyDown(KeyCode.Return))
        {
        //入力フォームのテキストを空にする
        inputField.text = "";
        if(username.Length > 4)
        {
            messageText.GetComponent<Text>().text = "4文字以内で入力してください";
        }
        else if(username.Length == 0)
        {
           messageText.GetComponent<Text>().text = "何か名前を入力してください";
        }
        else
        {
            messageText.GetComponent<Text>().text = $"{username}でいいですか？";
            enterButton.SetActive(true);
            backMessageButon.SetActive(true);
            backTitleButton.SetActive(false);
            InputField.SetActive(false);
        }
        }

    }

    public void ClickEnter()
    {
        PlayerPrefs.SetString("PLAYER_NAME", username);
        SceneManager.LoadScene("Door");
    }

    public void ClickBackText()
    {
        messageText.GetComponent<Text>().text = "名前を入力してくださいね(4文字以内)";
        enterButton.SetActive(false);
        backMessageButon.SetActive(false);
        backTitleButton.SetActive(true);
        InputField.SetActive(true);
    }

    public void ClickBackTitle()
    {
        if(messageText.GetComponent<Text>().text == "本当に戻りますか？(戻る場合はもう1度押してください)")
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            messageText.GetComponent<Text>().text = "本当に戻りますか？(戻る場合はもう1度押してください)";
        }
    }

}