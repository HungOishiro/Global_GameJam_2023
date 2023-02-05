using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MergedSlot : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] int id;
    [SerializeField] Image _iconImg;
    [SerializeField] Button _useItemButton;
    [SerializeField] TextMeshProUGUI _itemCountTxt;
    [SerializeField] Sprite _refImg;
    [SerializeField] Image fakeImage;
    
    int itemCount = 0;
    bool isDragging = false;

    private void Start()
    {
        _itemCountTxt.text = "x" + itemCount;
        _iconImg.sprite = _refImg;
        fakeImage.sprite = _refImg;

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

    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (itemCount <= 0) return;
        fakeImage.gameObject.SetActive(true);
        isDragging = true;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (itemCount <= 0) return;
        fakeImage.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (itemCount <= 0) return;
        isDragging = false;
        NamePrefabPool namePrefabPool = NamePrefabPool.NormalBoom;
        Vector2 spawnEffPos = fakeImage.transform.position;
        switch (id)
        {
            case 0:
                namePrefabPool = NamePrefabPool.NormalBoom;
                break;
            case 1:
                namePrefabPool = NamePrefabPool.FireBoom;
                break;
            case 2:
                namePrefabPool = NamePrefabPool.FreezeBoom;
                spawnEffPos = Vector2.zero;
                break;
            case 3:
                namePrefabPool = NamePrefabPool.StunBoom;
                break;
        }
        GameObject eff = PoolingManager.Instance.GetObject(namePrefabPool, spawnEffPos);
        fakeImage.gameObject.SetActive(false);
        fakeImage.transform.localPosition = Vector3.zero;
        UpdateSlot(-1);
        StartCoroutine(WaitDisableEffect(eff, 1));
        Debug.Log("USE");
    }

    IEnumerator WaitDisableEffect(GameObject eff, float time)
    {
        yield return new WaitForSeconds(time);
        eff.SetActive(false);
    }
}
