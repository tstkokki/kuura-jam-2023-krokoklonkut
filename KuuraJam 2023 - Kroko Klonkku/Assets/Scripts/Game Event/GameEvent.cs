using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Custom/Game Event")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new();
    public void Clear()
    {
        listeners.Clear();
    }

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            if (listeners[i] != null)
                listeners[i].Invoke();
        }
    }

    public void Add(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void Remove(GameEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
