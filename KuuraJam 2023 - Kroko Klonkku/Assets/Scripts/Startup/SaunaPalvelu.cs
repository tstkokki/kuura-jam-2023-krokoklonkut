using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sauna Palvelu", menuName = "Custom/Service/Sauna")]
public class SaunaPalvelu : ScriptableObject
{
    [SerializeField]
    SaunaUkkoState Istuu;
    [SerializeField]
    SaunaUkkoState Liikkeella;
    [SerializeField]
    SaunaUkkoState Suihkussa;

    public void LaitaIstumaan(SaunaUkko ukko)
    {
        ukko.State = Istuu;
    }
    public void LaitaLiikkeelle(SaunaUkko ukko)
    {
        ukko.State = Liikkeella;
    }
    public void PoistuSuihkusta(SaunaUkko ukko)
    {
        ukko.ResetHp();
        ukko.State = Suihkussa;
    }

    public void LaitaKlonkku(SaunaUkko ukko)
    {
        ukko.IsKlonkku = true;
    }
    
    public void PalautaKlonkku(SaunaUkko ukko)
    {
        ukko.IsKlonkku = false;
    }

    public bool OnkoIstumassa(SaunaUkko ukko)
    {
        return ukko.State == Istuu;
    }
    public bool OnkoLiikkeella(SaunaUkko ukko)
    {
        return ukko.State == Liikkeella;
    }
    public bool OnkoSuihkussa(SaunaUkko ukko)
    {
        return ukko.State == Suihkussa;
    }

    public bool OnkoKlonkku(SaunaUkko ukko)
    {
        return ukko.IsKlonkku;
    }

}
