using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

[System.Serializable]
public class EntityStats : SerializedMonoBehaviour
{
    public Entity parentEntity;
    public Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();
    public void Init(Entity parentEntity)
    {
        this.parentEntity = parentEntity;
        // Initialize stats based on the Enum values
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            stats[statType] = new Stat((float)statType);
        }
    }
    public Stat GetStat(StatType stat)
    {
        if (stats.ContainsKey(stat))
        {
            return stats[stat];
        }
        return null; // Default value if stat not found
    }
    public float GetStatValue(StatType stat)
    {
        if (stats.ContainsKey(stat))
        {
            return stats[stat].Value;
        }
        return -1; // Default value if stat not found
    }
    public void AddModifierToStat(StatType statType, params StatModifier[] modifiers)
    {
        if (stats.ContainsKey(statType))
        {
            foreach (StatModifier modifier in modifiers)
            {
                if (modifier != null)
                {
                    stats[statType].AddStatModifier(modifier);
                }
            }
        }
    }
}
