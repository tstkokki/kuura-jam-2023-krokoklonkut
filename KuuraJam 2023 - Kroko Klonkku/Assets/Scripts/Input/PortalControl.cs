using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    [SerializeField]
    List<GameEvent> portaalit = new();


    [SerializeField]
    IntVariable currentPortaali;
    /// <summary>
    /// portaalit 1,2 ja 3
    /// </summary>
    /// <param name="portaali"></param>
    public void Aseta(int portaali)
    {
        currentPortaali.Value = portaali >= 0 && portaali < portaalit.Count ? portaali : 0;
        portaalit[currentPortaali.Value].Raise();
    }
}
