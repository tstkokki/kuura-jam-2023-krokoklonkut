using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkkoSaunaanOnAwake : MonoBehaviour
{
    [SerializeField]
    SaunaUkkoLista lista;

    private void Awake()
    {
        SaunaUkko me = GetComponent<SaunaUkko>();
        if (me != null && lista != null)
            lista.AddUkko(me);
    }
}
