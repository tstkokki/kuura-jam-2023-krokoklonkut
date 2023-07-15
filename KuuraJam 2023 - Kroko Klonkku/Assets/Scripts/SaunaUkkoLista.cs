using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaUkkoLista : ScriptableObject
{
    List<SaunaUkko> lista = new();

    public void AddUkko(SaunaUkko ukko)
    {
        if (!lista.Contains(ukko))
            lista.Add(ukko);
    }

    public void RemoveUkko(SaunaUkko ukko)
    {
        if (lista.Contains(ukko))
            lista.Remove(ukko);
    }

    public List<SaunaUkko> GetList()
    {
        return lista;
    }

    public int Count
    {
        get { return lista.Count; }
    }
}
