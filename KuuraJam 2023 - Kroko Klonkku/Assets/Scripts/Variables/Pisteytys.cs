using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Pisteytys", menuName = "Custom/Pisteytys")]
public class Pisteytys : ScriptableObject
{
    [SerializeField]
    IntVariable pisteet;

    public int Pisteet
    {
        get
        {
            return pisteet.Value;
        }
        set
        {
            pisteet.Value = value;
        }
    }
}
