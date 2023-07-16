using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkkoSaunaanOnAwake : MonoBehaviour
{
    [SerializeField]
    SaunaUkkoLista lista;

    private void OnEnable()
    {
        SaunaUkko me = GetComponent<SaunaUkko>();
        if (me != null && lista != null)
            lista.AddUkko(me);
    }

    private void OnDisable()
    {
        SaunaUkko me = GetComponent<SaunaUkko>();
        if (me != null && lista != null)
            lista.RemoveUkko(me);
    }
}
