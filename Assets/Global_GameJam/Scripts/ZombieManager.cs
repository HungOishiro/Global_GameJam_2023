using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] List<Transform> listSpawnZombie = new List<Transform>();

    private void Start()
    {
        
    }

    void SpawnZombie()
    {
        int randZombie = Random.Range(0, 3);
        switch (randZombie)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
        //PoolingManager.Instance.GetObject()
    }
}
