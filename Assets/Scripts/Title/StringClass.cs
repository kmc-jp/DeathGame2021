using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringClass : MonoBehaviour
{

    public static readonly string[] ActorName =
    {
        $"{PlayerPrefs.GetString("PLAYER_NAME")}",
        "相棒"
    };
    public static readonly string Text0 = "←出口";
    public static readonly string Text1 = "操作説明";
    public static readonly string Text2 = "冒険をはじめる→";

    public static readonly string Text3 = "いやな予感がする...今はやめておこう";

    public static readonly string Text4 = "";

    public static readonly string Text5 = "";
    public static readonly string Text6 = "";
    public static readonly string Text7 = "";
    public static readonly string Text8 = "";
     public static readonly string Text9 = "";
    public static readonly string Text10 = "";
    public static readonly string Text11 = "";
    public static readonly string Text12= "このまま進んでよろしいですか？(進む場合はzキーを押してください)";
    public static readonly string[] Texts =
    {
        Text0,
        Text1,
        Text2,
        Text3,
        Text4,
        Text5,
        Text6,
        Text7,
        Text8,
        Text9,
        Text10,
        Text11,
        Text12
    };


    public static readonly string SutefuriyaText0 = "";
    public static readonly string SutefuriyaText1 = "あなたの力を調整いたしましょうか";
    public static readonly string SutefuriyaText2 = $"1:ステータスを変更する/2:{PlayerPrefs.GetString("PLAYER_NAME")}のわざを変更する";
    public static readonly string SutefuriyaText3 = "どなたのステータスを変更しますか？";
    public static readonly string SutefuriyaText4 = $"{PlayerPrefs.GetString("PLAYER_NAME")}さんの振り分けをします";
    public static readonly string SutefuriyaText5 = "";
    public static readonly string SutefuriyaText6 = "それではいってらっしゃいませ";
    public static readonly string SutefuriyaText7 = "";
    public static readonly string SutefuriyaText8 = $"{PlayerPrefs.GetString("PLAYER_NAME")}さんのわざを変更します";
    public static readonly string SutefuriyaText9 = "";
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
        SutefuriyaText9
    };

}
