using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ClearMessageWindow : MessageWindow
{
    [SerializeField]
    private AudioSource buttonSE; 
    public void CloseClearWindow()
    {
        buttonSE.PlayOneShot(buttonSE.clip);
        if (texts.Count == 0)
        {
            this.textField.text = "";
            this.background.gameObject.SetActive(false);
            closeSubject.OnNext(Unit.Default);
        }
        ConsumeMessage();
    }
}
