using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStatus : MonoBehaviour
{
    [SerializeField]
    private Text hp;
    [SerializeField]
    private Text mp;
    
    // Start is called before the first frame update
    void Start()
    {
        this.hp.text ="";
        this.mp.text ="";
    }

    // Update is called once per frame
    void Update()
    {
        
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
