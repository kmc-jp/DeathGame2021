using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStatus : MonoBehaviour
{
    [SerializeField]
    private Text Name;
    [SerializeField]
    private Text hp;
    [SerializeField]
    private Text mp;
    public Image StatusPanel;

    public void SetNameText(string text)
    {
        this.Name.text = text;
    }

    public void SetHpText(string hpText)
    {
        this.hp.text = hpText;
    }

    public void SetMpText(string mpText)
    {
        this.mp.text = mpText;
    }
}
