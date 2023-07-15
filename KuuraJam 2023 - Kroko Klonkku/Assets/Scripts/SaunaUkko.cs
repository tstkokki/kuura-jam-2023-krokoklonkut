using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaUkko : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var col = other.GetComponent<ITarget>();
        col?.OnEnter(this);
    }
}
