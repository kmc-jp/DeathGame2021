using System;
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

    private List<string> texts;

    public Button CloseButton;
    
    private Subject<Unit> closeSubject = new Subject<Unit>();
    public IObservable<Unit> CloseObservable
    {
        get { return closeSubject; }
    }

    void Start()
    {
        this.texts = new List<string>();
        this.background.gameObject.SetActive(false);
    }

    public void MakeWindow(string message)
    {
        this.textField.text = message;
        this.background.gameObject.SetActive(true);
    }

    public void MakeWindow(List<string> messages)
    {
        this.texts = messages;
        UpdateMessage();
        this.background.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        // SE一旦これで
        BattleManager.Instance.PlayButtonSE();
        if (texts.Count == 0)
        {
            this.textField.text = "";
            this.background.gameObject.SetActive(false);
        }
        UpdateMessage();
    }

    private void UpdateMessage()
    {
        this.background.gameObject.SetActive(true);
        if (texts.Count == 0) return;
        this.textField.text = texts[0];
        texts.RemoveAt(0);
    }
}
