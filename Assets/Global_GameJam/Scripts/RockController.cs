using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockController : MonoBehaviour
{
    [SerializeField] Collider2D myCol;
    [SerializeField] LayerMask rockLayer;
    [SerializeField] GameObject unMerged, merged;

    Vector3 mousePosOffset;
    bool isDraging = false;
    bool canDrag = false;
    int rockId;
    SpawnRockSlot slot;

    public void SetupStart(SpawnRockSlot _slot, int _id)
    {
        canDrag = false;
        transform.localScale = Vector3.zero;
        transform.parent = _slot.transform;
        rockId = _id;
        slot = _slot;
        transform.DOLocalMove(Vector3.zero, .1f).SetEase(Ease.Linear);
        transform.DOScale(1, .1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            canDrag = true;
        });
        unMerged.SetActive(true);
        merged.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!canDrag) return;
        isDraging = true;
        myCol.enabled = false;
        transform.parent = null;
        mousePosOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Begin");
    }

    private void OnMouseDrag()
    {
        if (!canDrag) return;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePosOffset;
    }

    private void OnMouseUp()
    {
        if (!canDrag) return;
        isDraging = false;
        CheckRockDistance();
    }

    void CheckRockDistance()
    {
        canDrag = false;
        Collider2D col = Physics2D.OverlapCircle(transform.position, .2f, rockLayer);
        if (col)
        {
            Debug.Log(col.name);
            RockController rock = col.gameObject.GetComponent<RockController>();
            if (rock.rockId == 0 || rockId == 0)
            {
                MergeSuccess(rock);
            }
            else
            {
                MergeFail();
            }
        }
        else
        {
            transform.parent = slot.transform;
            transform.DOLocalMove(Vector2.zero, .1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                canDrag = true;
            });
        }
        myCol.enabled = true;
    }

    public void Merge(int id)
    {
        slot.HaveRock = false;
        transform.localScale = Vector3.zero;
        unMerged.SetActive(false);
        merged.SetActive(true);
        transform.DOScale(1, .1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Debug.Log("GOOD JOB");
            transform.DOMove(MergeSlotPanel.Instance.ListMergedSlot[id].transform.position, .2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                MergeSlotPanel.Instance.UpdateSlot(id, 1);
                this.gameObject.SetActive(false);
            });
            transform.DOScale(0, .2f).SetEase(Ease.Linear);
        });
        MergeSlotPanel.Instance.UpdateRock(-2);
    }

    public void MergeSuccess(RockController target)
    {
        slot.HaveRock = false;
        transform.DOMove(target.transform.position, .1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (rockId == 0)
            {
                target.Merge(target.rockId);
                this.gameObject.SetActive(false);
            }
            else
            {
                transform.parent = target.transform.parent;
                slot = target.transform.parent.GetComponent<SpawnRockSlot>();
                slot.HaveRock = false;
                Merge(rockId);
                target.transform.parent = null;
                target.gameObject.SetActive(false);
            }
        });
    }

    public void MergeFail()
    {
        transform.parent = slot.transform;
        transform.DOLocalMove(Vector2.zero, .1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            canDrag = true;
        });
    }
}
