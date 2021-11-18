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

    public bool MakeWindow()
    {
        ConsumeMessage();
        if (texts.Count == 0) return false;
        return true;
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

    public void AddMessage(List<string> messages)
    {
        this.texts.AddRange(messages);
    }

    public void AddMessage(string messages)
    {
        this.texts.Add(messages);
    }

    public void CloseWindow()
    {
        // SE一旦これで
        BattleManager.Instance.PlayButtonSE();
        if (texts.Count == 0)
        {
            this.textField.text = "";
            this.background.gameObject.SetActive(false);
            closeSubject.OnNext(Unit.Default);
        }
        ConsumeMessage();
    }

    private void ConsumeMessage()
    {
        UpdateMessage();
        if (texts.Count == 0) return;
        texts.RemoveAt(0);
    }

    private void UpdateMessage()
    {
        if (texts.Count == 0) return;
        this.background.gameObject.SetActive(true);
        this.textField.text = texts[0];
    }
}
