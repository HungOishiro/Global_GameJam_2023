using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ZombieProperty
{
    public int health;
    public float speed;
    public int damage;
}

public enum ZombieType
{
    Speed, Normal, Strong
}

public class ZombieManager : MonoBehaviour
{
    [SerializeField] GameObject normalZombie;

    private const float _startX = 11;
    private const float _maxHeight = 3f;
    private const float _minHeight = -2.5f;

    private void Start()
    {
        WaveStart(15,30);
    }

    public void WaveStart(int minSpawn, int maxSpawn)
    {
        int timeSpawn = Random.Range(minSpawn, maxSpawn);
        const int zoombiePerTime = 2;
        const float timeWaitPerSpawn = 4.5f;
        
        float timeCount = 0f;

        for (int i = 0; i < timeSpawn; i += zoombiePerTime)
        {
            timeCount += timeWaitPerSpawn;
            TimerManager.Instance.AddTimer(timeCount,() =>
            {
                Vector3 transSpawn = new Vector3(_startX, Random.Range(_minHeight, _maxHeight), 0);
                Pooling.Instantiate(normalZombie, transSpawn, Quaternion.identity);
            });
        }
    }
}
