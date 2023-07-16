using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Pisteytys", menuName = "Custom/Pisteytys")]
public class Pisteytys : ScriptableObject
{
    [SerializeField]
    IntVariable pisteet;

    public void AddPoints(int amount)
    {
        pisteet.Value += amount;
    }

    public int GetPoints()
    {
        return pisteet.Value;

    }

}
