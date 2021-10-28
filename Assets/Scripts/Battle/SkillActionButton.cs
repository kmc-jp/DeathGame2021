using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillActionButton : MonoBehaviour
{
    [SerializeField]
    private Text label;
    void Start()
    {
        
    }

    public void SetLabel(string value)
    {
        label.text = value;
    }

    public void OnClick()
    {
    }
}
