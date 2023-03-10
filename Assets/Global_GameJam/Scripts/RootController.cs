using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : SingletonMonoBehaviour<RootController>
{
    [SerializeField] Transform rockSpawnPosParent;
    List<SpawnRockSlot> _listSpawnPos = new List<SpawnRockSlot>();
    int health = 10;

    private void Start()
    {
        for (int i = 0; i < MergeSlotPanel.Instance._rockSpawnPos.Count; i++)
        {
            _listSpawnPos.Add(MergeSlotPanel.Instance._rockSpawnPos[i].GetComponent<SpawnRockSlot>());
        }
    }

    private void OnMouseDown()
    {
        SpawnRock();
    }

    void SpawnRock()
    {
        if (!MergeSlotPanel.Instance.CanSpawnRock())
            return;
        
        int rockRand = Random.Range(0, _listSpawnPos.Count);
        
        if (!_listSpawnPos[rockRand].HaveRock)
            _listSpawnPos[rockRand].SpawnRock(RandomRock());
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

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(1f);
        health--;
        if (health > 0)
            StartCoroutine("Hit");
        else
        {
            PlayerManager.Instance.EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine("Hit");
        }
    }
}
