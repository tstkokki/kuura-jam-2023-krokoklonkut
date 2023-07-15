using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuihkuControl : MonoBehaviour
{
    [SerializeField]
    GameEvent nostaLampoa;
    [SerializeField]
    GameEvent laskeLampoa;


    public void Adjust(int amount)
    {
        if (amount < 0)
            laskeLampoa.Raise();
        if (amount > 0)
            nostaLampoa.Raise();
    }
}
