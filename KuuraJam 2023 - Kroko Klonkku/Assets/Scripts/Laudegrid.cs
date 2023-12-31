using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laudegrid : MonoBehaviour
{
    public List<Vector3Variable> laudeGrid;
    public SaunaUkkoLista saunaUkkoLista;
    public int klonkkuThreshold;
    public SaunaUkkoState klonkkuState;
    public SaunaUkkoState movingState;
    public List<SaunaUkko> testiUkot;
    private void Start()
    {
        ArrangeUkotToSeats();
    }
    public void ArrangeUkotToSeats()
    {
        List<SaunaUkko> saunaUkkoList = saunaUkkoLista.GetList();
        for (int i = 0; i < saunaUkkoList.Count; i++)
        {
            SaunaUkko ukko = saunaUkkoList[i];
            MovementScript saunaUkkoMovement = ukko.GetComponentInChildren<MovementScript>();
            if (i >= 0 && i < laudeGrid.Count)
            {
                saunaUkkoMovement.SetGoal(laudeGrid[i]);
            }
            else
            {
                saunaUkkoMovement.SetGoal(laudeGrid[laudeGrid.Count - 1]);
            }
            //if (ukko.State == klonkkuState)
            //{
            //    ukko.State = movingState;
            //}
            if (i >= klonkkuThreshold)
            {
                ukko.State = klonkkuState;
                ukko.LaitaKlonkuksi(true);
            }
            else
                ukko.LaitaKlonkuksi(false);

        }
    }

    public void AddTestiUkot()
    {
        foreach (SaunaUkko saunaUkko in testiUkot)
        {
            AddUkko(saunaUkko);
        }
    }

    public void AddUkko(SaunaUkko ukko)
    {
        print("kjeh kjeh");
        saunaUkkoLista.AddUkko(ukko);
        ArrangeUkotToSeats();
    }
    public void RemoveUkko(SaunaUkko ukko)
    {
        saunaUkkoLista.RemoveUkko(ukko);
    }
}
