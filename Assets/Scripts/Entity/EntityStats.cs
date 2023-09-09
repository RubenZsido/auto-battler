using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityStats : SerializedMonoBehaviour
{
    [HideInInspector]
    public Entity parentEntity;
    [TabGroup("Base Values For Stats")]
    public Dictionary<StatType, float> baseValues = new Dictionary<StatType, float>();
    [TabGroup("Stats")]
    public Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();
    public void Init(Entity parentEntity)
    {
        this.parentEntity = parentEntity;
        // Initialize stats based on the Enum values
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            if (baseValues.ContainsKey(statType))
            {
                stats[statType] = new Stat(baseValues[statType]);
            }
            else
            {
                stats[statType] = new Stat(0);
            }
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
