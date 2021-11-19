using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStringClass : MonoBehaviour
{
    public static readonly string SutefuriyaText0 = "";
    public static readonly string SutefuriyaText1 = "あなたの力を調整いたしましょうか";
    public static readonly string SutefuriyaText2 = $"1:ステータスを変更する/2:{PrefsUtil.GetPlayerName()}のわざを変更する";
    public static readonly string SutefuriyaText3 = $"どなたのステータスを変更しますか？\n1:{PrefsUtil.GetPlayerName()}　2: 相棒";
    public static readonly string SutefuriyaText4 = $"{PrefsUtil.GetPlayerName()}さんへの振り分けですね";
    public static readonly string SutefuriyaText5 = "";
    public static readonly string SutefuriyaText6 = "それではいってらっしゃいませ";
    public static readonly string SutefuriyaText7 = "";
    public static readonly string SutefuriyaText8 = $"{PrefsUtil.GetPlayerName()}さんのわざを変更します";
    public static readonly string SutefuriyaText9 = "";
    public static readonly string SutefuriyaText10 = "相棒さんの振り分けですね";
    public static readonly string SutefuriyaText11 = "";
    
    public static readonly string[] SutefuriyaTexts =
    {
        SutefuriyaText0,
        SutefuriyaText1,
        SutefuriyaText2,
        SutefuriyaText3,
        SutefuriyaText4,
        SutefuriyaText5,
        SutefuriyaText6,
        SutefuriyaText7,
        SutefuriyaText8,
        SutefuriyaText9,
        SutefuriyaText10,
        SutefuriyaText11
    };

}