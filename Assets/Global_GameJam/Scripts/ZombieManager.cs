using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProperty
{
    public int health;
    public int speed;
    public int damage;
}

public enum ZombieType
{
    Speed, Normal, Strong
}

public class ZombieManager : MonoBehaviour
{
    [SerializeField] GameObject normalZombie;
    [SerializeField] GameObject speedZombie;
    [SerializeField] GameObject bigZombie;

    private const float _startX = 11;
    private const float _maxHeight = 3f;
    private const float _minHeight = -2.5f;

    private void Start()
    {
        WaveStart(7,15);
    }

    GameObject RandomTempZombie()
    {
        int percentRand = Random.Range(0, 100);
        if (percentRand > 90)
        {
            //rare zombile spawn
            return bigZombie;
        }
        else
        {
            //normal zombie
            return normalZombie;
        }
    }

    public void WaveStart(int minSpawn, int maxSpawn)
    {
        int timeSpawn = Random.Range(minSpawn, maxSpawn);
        const int zoombiePerTime = 2;
        const float timeWaitPerSpawn = 1.5f;
        
        float timeCount = 0f;

        for (int i = 0; i < timeSpawn; i += zoombiePerTime)
        {
            timeCount += timeWaitPerSpawn;
            TimerManager.Instance.AddTimer(timeCount,() =>
            {
                Vector3 transSpawn = new Vector3(_startX, Random.Range(_minHeight, _maxHeight), 0);
                Pooling.Instantiate(RandomTempZombie(), transSpawn, Quaternion.identity);
            });
        }
    }
}
