using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sittingZone : MonoBehaviour
{
    public SaunaUkkoState sittingState;
    public SaunaUkkoState movingState;
    public SaunaUkkoState klonkkuState;
    public SaunaPalvelu saunaPalvelu;
    private void OnTriggerEnter(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if (saunaUkko != null)
        {
            saunaPalvelu.LaitaIstumaan(saunaUkko);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
        if (saunaUkko != null)
        {

            SpriteRenderer sr = saunaUkko.GetComponentInChildren<SpriteRenderer>();
            if (!saunaUkko.IsKlonkku && sr != null)
            {
                sr.flipX = true;
            }
        }
    }
    //private void OnTriggerExit(Collider col)
    //{
    //    var saunaUkko = col.GetComponentInChildren<SaunaUkko>();
    //    if (saunaUkko != null)
    //    { 
            
    //    }
    //}
}
