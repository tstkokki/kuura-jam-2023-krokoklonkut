using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Custom/Game Event")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();


    public void Raise()
    {
        for (int i = listeners.Count-1; i > 0; i--)
        {
            listeners[i].Invoke();
        }
    }

    public void Add(GameEventListener listener)
    {

        listeners.Add(listener);
    }

    public void Remove(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
