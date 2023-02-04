using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static int TotalLevel = 30;
    public static bool CanShowBanner = true;

    public static string SceneBeforeOpen
    {
        get => PlayerPrefs.GetString("SceneBeforeOpen", "");
        set
        {
            PlayerPrefs.SetString("SceneBeforeOpen", value);
        }
    }

    public static int firstDailyRewardLevel = 1;

    public static int Day
    {
        get { return PlayerPrefs.GetInt("day", 0); }
        set { PlayerPrefs.SetInt("day", value); }
    }
    public static int FirstDay
    {
        get { return PlayerPrefs.GetInt("FirstDay", 0); }
        set { PlayerPrefs.SetInt("FirstDay", value); }
    }
}
