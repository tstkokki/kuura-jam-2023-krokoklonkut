using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauna : MonoBehaviour
{
    public SaunaUkkoLista Saunojat;
    public int LoylyVoima = 30;
    public void LoylyaKiukaaseen()
    {
        foreach (var ukko in Saunojat.GetList())
        {
            ukko.OttaaLoylya(LoylyVoima);
        }
    }
}
