using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, ITarget
{

    [SerializeField]
    List<Vector3Variable> portaalit = new List<Vector3Variable>();

    [SerializeField]
    Vector3Variable SuihkuPortaali;

    [SerializeField]
    Vector3Variable Suihku;

    [SerializeField]
    SaunaPalvelu palvelu;

    public void Siirry(int portaali)
    {
        Debug.Log($"Siirry {portaali}");
        transform.position = portaalit[portaali >= 0 && portaali < portaalit.Count ? portaali : 0].Position;
    }

    public void OnEnter(SaunaUkko ukko)
    {
        if(SuihkuPortaali != null && palvelu.OnkoLiikkeella(ukko))
        {
            ukko.transform.position = SuihkuPortaali.Position;
            ukko.GoToNext(Suihku);
        }
    }
}
