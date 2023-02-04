using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSlotPanel : SingletonMonoBehaviour<MergeSlotPanel>
{
    [SerializeField] List<MergedSlot> listMergedSlot = new List<MergedSlot>();

    public List<MergedSlot> ListMergedSlot
    {
        get => listMergedSlot;
    }

    public void UpdateSlot(int id, int count)
    {
        listMergedSlot[id].UpdateSlot(count);
    }
}
