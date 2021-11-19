using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ClearMessageWindow : MessageWindow
{
    public void CloseClearWindow()
    {
        if (texts.Count == 0)
        {
            this.textField.text = "";
            this.background.gameObject.SetActive(false);
            closeSubject.OnNext(Unit.Default);
        }
        ConsumeMessage();
    }
}
