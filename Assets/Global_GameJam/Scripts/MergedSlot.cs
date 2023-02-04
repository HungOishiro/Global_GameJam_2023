using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MergedSlot : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Image iconImg;
    [SerializeField] Button useItemButton;
    [SerializeField] TextMeshProUGUI itemCountTxt;

    [SerializeField] List<Sprite> listIconSprite = new List<Sprite>();
    int itemCount = 0;

    private void Start()
    {
        itemCountTxt.text = "x" + itemCount;
        iconImg.sprite = listIconSprite[id];

        useItemButton.onClick.AddListener(() => UseItem());
    }

    public void UpdateSlot(int count)
    {
        itemCount += count;
        itemCountTxt.text = "x" + itemCount;
    }

    void UseItem()
    {
        Debug.Log("USE");
    }
}
