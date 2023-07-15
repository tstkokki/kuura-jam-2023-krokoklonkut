using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoylynHeitto : MonoBehaviour
{
    [SerializeField]
    List<GameEvent> Saunat = new();

    [SerializeField]
    IntVariable CurrentRoom;
    public void Heita()
    {
        if( Saunat.Count > 0 && CurrentRoom.Value >= 0 && CurrentRoom.Value < Saunat.Count)
        {
            Saunat[CurrentRoom.Value].Raise();
        }
    }
}
