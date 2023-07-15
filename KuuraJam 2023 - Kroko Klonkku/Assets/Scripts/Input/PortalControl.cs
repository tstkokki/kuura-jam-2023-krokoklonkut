using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    [SerializeField]
    List<GameEvent> portaalit = new List<GameEvent>();
    
    /// <summary>
    /// portaalit 1,2 ja 3
    /// </summary>
    /// <param name="portaali"></param>
    public void Aseta(int portaali)
    {
        portaalit[portaali >= 0 && portaali < portaalit.Count ? portaali : 0].Raise();
    }
}
