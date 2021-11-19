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

    public static void SetPlayerStatus(int hp, int mp, int atk, int def, int agi )
    {
         string status = JsonUtility.ToJson(new AdditionalStatus(hp, mp, atk, def, agi));
         PlayerPrefs.SetString("PLAYER_STATUS", status);
    }

    public static AdditionalStatus GetPlayerStatus()
    {
        string json = PlayerPrefs.GetString("PLAYER_STATUS", null);
        AdditionalStatus status = JsonUtility.FromJson<AdditionalStatus>(json);
        return status;
    }

    public static void SetBuddyStatus(int hp, int mp, int atk, int def, int agi )
    {
         string status = JsonUtility.ToJson(new AdditionalStatus(hp, mp, atk, def, agi));
         PlayerPrefs.SetString("BUDDY_STATUS", status);
    }

    public static AdditionalStatus GetBuddyStatus()
    {
        string json = PlayerPrefs.GetString("BUDDY_STATUS", null);
        AdditionalStatus status = JsonUtility.FromJson<AdditionalStatus>(json);
        return status;
    }
}
