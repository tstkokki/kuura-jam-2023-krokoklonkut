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

    [SerializeField]
    GameEvent ArrangeUkot;

    [SerializeField]
    SaunaPalvelu palvelu;

    public void OnEnter(SaunaUkko ukko)
    {
        if (palvelu.OnkoSuihkussa(ukko))
        {

            ukko.transform.position = portaalit[PortalIndex()].Position;
            saunat[currentPortal.Value >= 0 && currentPortal.Value < saunat.Count ? currentPortal.Value : 0].AddUkko(ukko);
            ArrangeUkot.Raise();
        }
    }

    private int PortalIndex()
    {
        return currentPortal.Value >= 0 && currentPortal.Value < portaalit.Count ? currentPortal.Value : 0;
    }
}
