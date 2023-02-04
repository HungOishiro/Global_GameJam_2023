using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public RootController root;
    public Transform rockSpawnPosParent;
    public int rockCount;

    public void UpdateRock(int rockAdded)
    {
        rockCount += rockAdded;
    }

    public bool CanSpawnRock()
    {
        return rockCount < rockSpawnPosParent.childCount;
    }
}
