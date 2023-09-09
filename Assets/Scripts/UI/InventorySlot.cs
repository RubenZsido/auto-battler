using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    AbilityCard card;
    public AbilityListManager abilityListManager;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount >= 1)
        {
            return;
        }
        GameObject dropped = eventData.pointerDrag.gameObject;
        AddItem(dropped);
        OnAdded();
    }
    public void AddItem(GameObject dropped)
    {
        DraggableItem item = dropped.GetComponent<DraggableItem>();
        item.parentBeforeDrag = this.transform;
        card = dropped.GetComponent<AbilityCard>();
    }
    public void OnRemoved()
    {
        if (card == null)
        {
            return;
        }
        abilityListManager.RemoveAbility(card.ability);
    }
    public void OnAdded()
    {
        if (card == null)
        {
            return;
        }
        abilityListManager.AddAbility(card.ability);
    }
}
