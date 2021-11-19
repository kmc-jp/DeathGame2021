using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefsUtil
{
    public static int GetStageProgress()
    {
        int progress = PlayerPrefs.GetInt("STAGE_PROGRESS", 0);
        return progress;
    }

    public static int UpdateStageProgress()
    {
        int progress = GetStageProgress() + 1;
        SetStageProgress(progress);
        return progress;
    }

    private static void SetStageProgress(int stage)
    {
        PlayerPrefs.SetInt("STAGE_PROGRESS", stage);
    }

    public static string GetPlayerName()
    {
        string name = PlayerPrefs.GetString("PLAYER_NAME", "player");
        return name;
    }

    public static void SetPlayerName(string name)
    {
        PlayerPrefs.SetString("PLAYER_NAME", name);
    }
}
