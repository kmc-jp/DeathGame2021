using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MessageWindow : SingletonMonoBehaviour<MessageWindow>
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private Text textField;

    public Button CloseButton;

    void Start()
    {
        this.background.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void MakeWindow(string message)
    {
        this.textField.text = message;
        this.background.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        // SE一旦これで
        BattleManager.Instance.PlayButtonSE();
        this.textField.text = "";
        this.background.gameObject.SetActive(false);
    }
}
