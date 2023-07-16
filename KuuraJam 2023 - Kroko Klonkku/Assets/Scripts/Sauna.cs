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

    [SerializeField]
    Vector3Variable portaali;

    public SaunaUkkoLista Saunojat;
    public int LoylyVoima = 30;

    public int saunojanPisteet = 10;
    public int klonkkuPenalty = -960;

    Queue<SaunaUkko> heikot = new();

    [SerializeField]
    GameEvent ArrangeUkot;

    public void LoylyaKiukaaseen()
    {
        foreach (var ukko in Saunojat.GetList())
        {
            LoylynVaikutukset(ukko, LoylyVoima, saunojanPisteet);
        }
        HoidaHeikot();
    }

    private void HoidaHeikot()
    {
        if (heikot.Count > 0)
        {
            while (heikot.Count > 0)
            {
                var ukko = heikot.Dequeue();
                ukko.LaitaLiikkeelle(portaali);
                Saunojat.RemoveUkko(ukko);
            }
            ArrangeUkot.Raise();
        }
    }

    private void LoylynVaikutukset(SaunaUkko ukko, int loylyVoima, int pisteet)
    {
        ukko.OttaaLoylya(loylyVoima);
        PisteetUkosta(ukko, pisteet);
        if (ukko.EiJaksaSaunoa())
        {
            heikot.Enqueue(ukko);
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
                    LoylynVaikutukset(ukko, 10, 5);
                }
                HoidaHeikot();
            });
    }

    private void PisteetUkosta(SaunaUkko ukko, int pisteet)
    {
        int amt = ukko.JaksaaSaunoa
        ? pisteet
        : ukko.IsKlonkku
        ? klonkkuPenalty
        : 0;
        pisteytys.AddPoints(amt);
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
