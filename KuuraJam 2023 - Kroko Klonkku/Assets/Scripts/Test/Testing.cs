using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public SaunaUkkoLista saunaLista;
    public SaunaUkko ukko;

    public void LisaaUkkoSaunaan()
    {
        var list = saunaLista.GetList();
        if(list != null && !list.Contains(ukko))
            list.Add(ukko);
    }

    public void LaitaKlonkku()
    {
        ukko.IsKlonkku = !ukko.IsKlonkku;
    }

    private void OnDisable()
    {
        saunaLista.GetList().Clear();
    }
}
