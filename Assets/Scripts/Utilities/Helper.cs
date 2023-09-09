using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static void ModifyStat(float Flat, float PercentAdd, float PercentMult, Entity parent, StatType statType, object source)
    {
        Stat stat = (Stat)parent.stats.GetType().GetField(statType.ToString()).GetValue(parent.stats);
        if (Flat != 0)
        {
            stat.AddStatModifier(new StatModifier(Flat, StatModType.Flat, source));
        }
        if (PercentAdd != 0)
        {
            stat.AddStatModifier(new StatModifier(PercentAdd, StatModType.PercentAdd, source));
        }
        if (PercentMult != 0)
        {
            stat.AddStatModifier(new StatModifier(PercentMult, StatModType.PercentMult, source));
        }
    }
    
}
