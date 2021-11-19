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
        "ここまで遊んでいただき本当にありがとうございます。",
        "タイトルへもどります。"
    };
    void Start()
    {
        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        ClearMessageWindow.Instance.MakeWindow(messages);
        yield return ClearMessageWindow.Instance.CloseObservable.First().ToYieldInstruction();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Title");
    }
}
