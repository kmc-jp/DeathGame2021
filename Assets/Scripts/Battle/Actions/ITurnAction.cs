using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ITurnAction
{
    // 優先度 0がデフォルト 大きいほど早く行動する
    int Priority
    {
        get;
    }

    IActor Actor
    {
        get;
        set;
    }

    // ウィンドウを開かないときはfalse
    bool Prepare();
    
    UniTask Exec();
}
