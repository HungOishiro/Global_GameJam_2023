using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockSlot : MonoBehaviour
{
    bool haveRock = false;
    int rockId = -1;

    public bool HaveRock
    {
        get => haveRock;
        set
        {
            haveRock = value;
        }
    }

    public void SpawnRock(int id)
    {
        if (haveRock) return;

        haveRock = true;

        NamePrefabPool rockName = NamePrefabPool.RockNormal;
        int rockId = 0;

        if (id == 0)
        {
            rockName = NamePrefabPool.RockNormal;
            rockId = 0;
        }
        else
        {
            int rockRand = Random.Range(0, 3);
            switch (rockRand)
            {
                case 0:
                    rockName = NamePrefabPool.RockFire;
                    rockId = 1;
                    break;
                case 1:
                    rockName = NamePrefabPool.RockFreeze;
                    rockId = 2;
                    break;
                case 2:
                    rockName = NamePrefabPool.RockStun;
                    rockId = 3;
                    break;
            }
        }

        RockController rock = PoolingManager.Instance.GetObject(rockName, GameManager.Instance.root.transform.position).GetComponent<RockController>();
        rock.SetupStart(this, rockId);

        GameManager.Instance.UpdateRock(1);
    }
}
