using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageMaster
{
    private static string PrefabPath = "Prefabs/Enemys/";
    // ステージごとに生成するEnemyプレハブ
    private static readonly Dictionary<int, List<string>> Stage = new Dictionary<int, List<string>>{
        { 0, new List<string>() {"Floor1"} },
        { 1, new List<string>() {"Floor2"} },
        { 2, new List<string>() {"Floor3A", "Floor3B"} },
        { 3, new List<string>() {"Floor4"} },
        { 4, new List<string>() {"Floor5"} },
        { 5, new List<string>() {"Floor6"} },
        { 6, new List<string>() {"Boss"} },
    };

    public static List<GameObject> GetEnemyObjects(int stage)
    {
        List<string> enemyList = Stage[stage];
        List<GameObject> enemys = new List<GameObject>();
        foreach (string e in enemyList)
        {
            GameObject p = (GameObject)Resources.Load(PrefabPath + e);
            enemys.Add(p);
        }

        return enemys;
    }
}
