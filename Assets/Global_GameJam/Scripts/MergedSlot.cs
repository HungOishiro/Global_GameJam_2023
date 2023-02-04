using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MergedSlot : MonoBehaviour
{
    [SerializeField] Image _iconImg;
    [SerializeField] Button _useItemButton;
    [SerializeField] TextMeshProUGUI _itemCountTxt;
    [SerializeField] Sprite _refImg;
    
    int itemCount = 0;

    private void Start()
    {
        _itemCountTxt.text = "x" + itemCount;
        _iconImg.sprite = _refImg;

        _useItemButton.onClick.AddListener(UseItem);
    }

    private void OnDestroy()
    {
        _useItemButton.onClick.RemoveListener(UseItem);
    }

    public void UpdateSlot(int count)
    {
        itemCount += count;
        _itemCountTxt.text = "x" + itemCount;
    }

    void UseItem()
    {
        Debug.Log("USE");
    }
}
