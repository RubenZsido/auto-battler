using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class AbilityListManager : SerializedMonoBehaviour
{
    [SerializeField]
    public InventorySlot slotPrefab;
    public List<GameObject> slots;
    public bool isStatic;

    [OdinSerialize] public IAbilityHolder abilityHolder { get; set; }

    public void AddAbility(Ability ability)
    {
        abilityHolder.holder.Add(ability);
    }
    public void RemoveAbility(Ability ability)
    {
        abilityHolder.holder.Remove(ability);
    }
    private void AddInventorySlot()
    {
        InventorySlot slot = Instantiate(slotPrefab, transform);
        slot.abilityListManager = this;
        slots.Add(slot.gameObject);
    }
    private int GetCardCount()
    {
        int abilityCardCount = 0;
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount != 0)
            {
                abilityCardCount++;
            }
        }
        return abilityCardCount;
    }
    public void UpdateInventorySlots()
    {
        if (isStatic)
        {
            return;
        }
        //if slot count is higher than cardCount + 1, then we need to remove one
        if (GetCardCount() + 1 < slots.Count)
        {
            GameObject slotToRemove = slots[0];
            foreach (GameObject slot in slots)
            {
                if (slot.transform.childCount == 0)
                {
                    slotToRemove = slot;
                    continue;
                }
            }
            slots.Remove(slotToRemove);
            Destroy(slotToRemove);
        }
        Debug.Log("slots: " + slots.Count + "\ncards: " + GetCardCount());
        //if all the slots are full, add another slot
        if (slots.Count <= GetCardCount())
        {
            AddInventorySlot();
        }
    }

}
