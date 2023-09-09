using System;
using System.Collections.Generic;

public class EnumList<TEnum, TValueType> where TEnum : struct where TValueType : new()
{
    public Dictionary<TEnum, TValueType> events = new Dictionary<TEnum, TValueType>();
    public EnumList()
    {
        // Initialize GameEvents based on the Enum values
        foreach (TEnum GameEventType in Enum.GetValues(typeof(TEnum)))
        {
            events[GameEventType] = new TValueType();
        }
    }
    public TValueType GetListElement(TEnum GameEvent)
    {
        return events.TryGetValue(GameEvent, out TValueType value) ? value : default(TValueType);
    }
}