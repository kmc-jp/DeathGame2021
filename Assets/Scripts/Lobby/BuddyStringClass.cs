using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyStringClass : MonoBehaviour
{

    public static readonly string Text0 = "";
    public static readonly string Text1 = "よお";
    public static readonly string Text2 = "あの塔に行くんだろ？";

    public static readonly string Text3 = "連れて行ってくれよ。役には立つからさ";

    public static readonly string Text4 = "名前？　名前かぁ";

    public static readonly string Text5 = "とりあえず相棒って呼んでくれればそれで";
    public static readonly string Text6 = $"あんたは{PlayerPrefs.GetString("PLAYER_NAME")}ていうのか";
    public static readonly string Text7 = "よろしくな";
    public static readonly string Text8 = "相棒が仲間に加わった";
     public static readonly string Text9 = "";
    public static readonly string Text10 = "";
    public static readonly string Text11 = "";
    public static readonly string Text12= "";
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
}
