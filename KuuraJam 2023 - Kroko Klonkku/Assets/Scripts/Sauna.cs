using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Sauna : MonoBehaviour
{
    [SerializeField]
    Pisteytys pisteytys;

    [SerializeField]
    SaunaPalvelu saunaPalvelu;

    public SaunaUkkoLista Saunojat;
    public int LoylyVoima = 30;

    public int saunojanPisteet = 10;
    public int klonkkuPenalty = -60;

    public void LoylyaKiukaaseen()
    {
        foreach (var ukko in Saunojat.GetList())
        {
            ukko.OttaaLoylya(LoylyVoima);
        }
    }
    IDisposable _update;
    private void Start()
    {
        _update = Observable
            .Interval(TimeSpan.FromSeconds(5))
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {
                foreach (var ukko in Saunojat.GetList())
                {
                    pisteytys.Pisteet += ukko.JaksaaSaunoa
                    ? saunojanPisteet
                    : ukko.IsKlonkku
                    ? klonkkuPenalty
                    : 0;
                }
            });
    }

    private void OnDisable()
    {
        Saunojat.GetList().Clear();
    }
    private void OnDestroy()
    {
        if (_update != null)
            _update.Dispose();
    }
}
