using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    [SerializeField] Transform rockSpawnPosParent;
    List<SpawnRockSlot> listSpawnPos = new List<SpawnRockSlot>();

    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.rockSpawnPosParent.childCount; i++)
        {
            listSpawnPos.Add(GameManager.Instance.rockSpawnPosParent.GetChild(i).GetComponent<SpawnRockSlot>());
        }
    }

    private void OnMouseDown()
    {
        SpawnRock();
    }

    void SpawnRock()
    {
        if (!GameManager.Instance.CanSpawnRock()) return;
        int rockRand = Random.Range(0, listSpawnPos.Count);
        if (!listSpawnPos[rockRand].HaveRock)
            listSpawnPos[rockRand].SpawnRock(RandomRock());
        else
            SpawnRock();
    }

    int RandomRock()
    {
        int rand = Random.Range(0, 10);
        if (rand < 8)
            return 0;
        else
            return 1;
    }
}
