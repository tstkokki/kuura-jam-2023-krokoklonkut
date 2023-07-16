using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaUkko : MonoBehaviour
{
    [SerializeField] int LoylyRes = 20;
    [SerializeField] int Hp = 100;

    public bool IsKlonkku;
    public SaunaUkkoState State;

    [SerializeField]
    SaunaPalvelu saunaPalvelu;

    public void OttaaLoylya(int amount)
    {
        Hp -= Mathf.Max(amount - LoylyRes, 10);

        if(Hp <= 0 )
        {
            saunaPalvelu.LaitaIstumaan(this);
        }
    }

    public bool JaksaaSaunoa => !IsKlonkku 
        && (saunaPalvelu == null || saunaPalvelu.OnkoIstumassa(this)) 
        && LoylyRes > 0;


    public void GoToNext()
    {
        Debug.Log("Next state");
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.GetComponent<ITarget>();
        col?.OnEnter(this);
    }
}
