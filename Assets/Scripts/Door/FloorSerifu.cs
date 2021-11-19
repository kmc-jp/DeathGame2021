using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorSerifu : MonoBehaviour
{
    [SerializeField]
    private Text serifuText;

    void Start()
    {
        int floor = PrefsUtil.GetStageProgress();
        serifuText.text = $"ここは {floor + 1} 階層です";
    }
}
