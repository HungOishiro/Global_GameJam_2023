using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MergeSlotPanel : SingletonMonoBehaviour<MergeSlotPanel>
{
    [SerializeField] List<MergedSlot> _listMergedSlot = new List<MergedSlot>();
    public List<SpawnRockSlot> _rockSpawnPos;
    public int rockCount;
    
    public List<MergedSlot> ListMergedSlot => _listMergedSlot;

    public void UpdateSlot(int id, int count)
    {
        _listMergedSlot[id].UpdateSlot(count);
    }
    
    public void UpdateRock(int rockAdded)   
    {
        rockCount += rockAdded;
    }

    public bool CanSpawnRock()
    {
        return rockCount < _rockSpawnPos.Count;
    }
}
