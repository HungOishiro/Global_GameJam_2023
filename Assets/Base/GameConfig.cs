using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static int TotalLevel = 30;

    public static int Day
    {
        get { return PlayerPrefs.GetInt("day", 0); }
        set { PlayerPrefs.SetInt("day", value); }
    }
}
