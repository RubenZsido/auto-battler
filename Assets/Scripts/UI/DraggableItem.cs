using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler
{
    [AssetsOnly]
    public GlobalEventsSO eventHolder;
    public Ease easeType;
    public float duration = .15f;
    public List<Image> images;
    public InventorySlot slot;
    public Transform parentBeforeDrag;
    [HideInInspector] public RectTransform rectTransform;
    private bool isInspectingThis;
    bool isDragging;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        DOTween.Init();
        TryUpdateParentBeforeDrag(transform.parent);
        UpdateSlot();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        UIManager.Instance.FinishInspecting();
        isDragging = true;
        TryUpdateParentBeforeDrag(transform.parent);
        UpdateSlot();
        if (slot)
        {
            slot.OnRemoved();
        }
        PutOnTop(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        BackToParentBeforeDrag();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInspectingThis)
        {
            isInspectingThis = true;
            UIManager.Instance.InspectCard(this);
            return;
        }
        isInspectingThis = false;
        UIManager.Instance.FinishInspecting();
        return;

    }

    public void OnDrop(PointerEventData eventData)
    {
        /*
        //Switch
        GameObject dropped = eventData.pointerDrag.gameObject;
        DraggableItem upperItem = dropped.GetComponent<DraggableItem>();
        Transform thisParent = parentBeforeDrag;
        Transform otherParent = upperItem.parentBeforeDrag;

        upperItem.PutOnTop(true);
        PutOnTop(true);

        parentBeforeDrag = otherParent;
        upperItem.parentBeforeDrag = thisParent;
        BackToParent();
        upperItem.BackToParent();

        */
    }
    #region helper functions
    public void PutOnTop(bool raycastOff)
    {
        transform.SetParent(transform.root, true);
        transform.SetAsLastSibling();
        if (!raycastOff)
        {
            return;
        }
        images.ForEach(image => image.raycastTarget = false);
    }
    private void TryUpdateParentBeforeDrag(Transform parent)
    {
        if (parent && parent.gameObject.CompareTag("Slot"))
        {
            parentBeforeDrag = parent;
        }
    }
    private void UpdateSlot()
    {
        slot = parentBeforeDrag.GetComponent<InventorySlot>();
    }
    public void BackToParentBeforeDrag()
    {
        transform.DOMove(parentBeforeDrag.position, duration).SetEase(easeType).OnComplete(() =>
        {
            transform.SetParent(parentBeforeDrag);
            images.ForEach(image => image.raycastTarget = true);
            UpdateSlot();
            slot.abilityListManager.UpdateInventorySlots();
        });


    }
    #endregion


}
