using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, ITarget
{

    [SerializeField]
    List<Vector3Variable> portaalit = new List<Vector3Variable>();

    [SerializeField]
    Vector3Variable Suihku;



    public void Siirry(int portaali)
    {
        Debug.Log($"Siirry {portaali}");
        transform.position = portaalit[portaali >= 0 && portaali < portaalit.Count ? portaali : 0].Position;
    }

    public void OnEnter(SaunaUkko ukko)
    {
        Debug.Log("Ukko saapui");
        if(Suihku != null)
        {
            ukko.transform.position = Suihku.Position;
        }
    }
}
