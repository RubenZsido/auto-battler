using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class Stat
{
    // Editor value
    [SerializeField, ReadOnly]
    private float value;
    public float Value
    {
        get
        {
            float finalValue = baseValue;
            finalValue += Flat.Sum(x => x.Value);
            finalValue = finalValue + finalValue * PercentAdd.Sum(x => x.Value);
            float percentMultFinal = PercentMult.Sum(x => x.Value);
            if (PercentMult.Count != 0)
            {
                finalValue *= percentMultFinal;
            }
            value = finalValue;
            return finalValue;
        }
    }
    [SerializeField] private float baseValue = 0f;
    [SerializeField] private bool hasMin = false;
    [SerializeField] private float min = 1f;

    public List<StatModifier> Flat;
    public List<StatModifier> PercentAdd;
    public List<StatModifier> PercentMult;

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
        Flat = new List<StatModifier>();
        PercentAdd = new List<StatModifier>();
        PercentMult = new List<StatModifier>();
    }
    public void AddStatModifier(StatModifier mod)
    {
        switch (mod.Type)
        {
            case StatModType.Flat:
                Flat.Add(mod);
                break;
            case StatModType.PercentAdd:
                PercentAdd.Add(mod);
                break;
            case StatModType.PercentMult:
                PercentMult.Add(mod);
                break;
        }
    }

    public void RemoveStatModifier(StatModifier mod)
    {
        switch (mod.Type)
        {
            case StatModType.Flat:
                Flat.Remove(mod);
                break;
            case StatModType.PercentAdd:
                PercentAdd.Remove(mod);
                break;
            case StatModType.PercentMult:
                PercentMult.Remove(mod);
                break;
        }
    }

    public void RemoveStatModifiersFromSource(object source)
    {
        foreach (StatModifier mod in Flat)
        {
            if (mod.Source == source)
            {
                Flat.Remove(mod);
            }
        }
        foreach (StatModifier mod in PercentAdd)
        {
            if (mod.Source == source)
            {
                PercentAdd.Remove(mod);
            }
        }
        foreach (StatModifier mod in PercentMult)
        {
            if (mod.Source == source)
            {
                PercentMult.Remove(mod);
            }
        }
    }
    // Initialize coolDown with editor's value
    private void OnEnable()
    {

    }

    // You can also use OnAfterDeserialize for the other way around
    public void OnAfterDeserialize()
    {
    }
}
