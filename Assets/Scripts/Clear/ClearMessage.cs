using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class ClearMessage : MonoBehaviour
{
    private List<string> messages = new List<string>()
    {
        "あなたはついに頂上へたどり着きました。",
        "ここまで遊んでいただき\n本当にありがとうございます。",
        "タイトルへもどります。"
    };

    bool firstTime = true;
    void Update()
    {   
        if (firstTime)
        {
            firstTime = false;
            StartCoroutine(ShowMessage());
        }
    }

    private IEnumerator ShowMessage()
    {
        ClearMessageWindow.Instance.MakeWindow(messages);
        yield return ClearMessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
        yield return new WaitForSeconds(1f);
        PrefsUtil.ClearPrefs();
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
