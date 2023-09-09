using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypedEvent<T> : ScriptableObject
{
    private readonly List<Action<T>> eventListeners = new List<Action<T>>();

    public void Raise(T data)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i](data);
    }

    public void RegisterListener(Action<T> listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(Action<T> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
