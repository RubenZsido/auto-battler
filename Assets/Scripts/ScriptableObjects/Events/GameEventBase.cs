using System;
using System.Collections.Generic;
[Serializable]
public class GameEvent
{
    private readonly List<Action> eventListeners = new List<Action>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i]();
        }
    }

    public void RegisterListener(Action listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(Action listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}
[Serializable]
public class GameEvent<T>
{
    private readonly List<Action<T>> eventListeners = new List<Action<T>>();

    public void Raise(T data)
    {
        /*foreach (Action<T> func in eventListeners)
        {
            func(data);
        }*/
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

[Serializable]
public class GameEvent<T1, T2>
{
    private readonly List<Action<T1, T2>> eventListeners = new List<Action<T1, T2>>();

    public void Raise(T1 data1, T2 data2)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i](data1, data2);
        }
    }

    public void RegisterListener(Action<T1, T2> listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(Action<T1, T2> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}

[Serializable]
public class GameEvent<T1, T2, T3>
{
    private readonly List<Action<T1, T2, T3>> eventListeners = new List<Action<T1, T2, T3>>();

    public void Raise(T1 data1, T2 data2, T3 data3)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i](data1, data2, data3);
        }
    }

    public void RegisterListener(Action<T1, T2, T3> listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(Action<T1, T2, T3> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}