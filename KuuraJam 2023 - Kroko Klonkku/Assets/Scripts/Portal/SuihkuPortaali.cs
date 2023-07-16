using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuihkuPortaali : MonoBehaviour, ITarget
{

    [SerializeField]
    List<Vector3Variable> portaalit = new List<Vector3Variable>();
    
    [SerializeField]
    List<SaunaUkkoLista> saunat = new List<SaunaUkkoLista>();

    [SerializeField]
    IntVariable currentPortal;

    public void OnEnter(SaunaUkko ukko)
    {

        ukko.transform.position = portaalit[PortalIndex()].Position;

    }

    private int PortalIndex()
    {
        return currentPortal.Value >= 0 && currentPortal.Value < portaalit.Count ? currentPortal.Value : 0;
    }
}
