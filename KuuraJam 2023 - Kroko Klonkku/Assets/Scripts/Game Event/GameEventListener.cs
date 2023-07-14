using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent _event;


    public void Invoke()
    {
        _event?.Invoke();
    }

    private void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.Add(this);
    }

    private void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.Remove(this);
    }
}
