using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sittingZone : MonoBehaviour
{
    public SaunaUkkoState sittingState;
    public SaunaUkkoState movingState;
    private void OnTriggerEnter(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if(saunaUkko != null)
        {
            saunaUkko.State = sittingState;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if (saunaUkko != null)
        {
            saunaUkko.State = movingState;
        }
    }
}
