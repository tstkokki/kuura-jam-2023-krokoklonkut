using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sittingZone : MonoBehaviour
{
    public SaunaUkkoState sittingState;
    public SaunaUkkoState movingState;
    public SaunaUkkoState klonkkuState;
    private void OnTriggerEnter(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if(saunaUkko != null && saunaUkko.State != klonkkuState)
        {
            saunaUkko.State = sittingState;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if (saunaUkko != null && saunaUkko.State != klonkkuState)
        { 
            saunaUkko.State = movingState;
        }
    }
}
