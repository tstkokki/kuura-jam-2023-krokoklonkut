using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaUkko : MonoBehaviour
{

    public void GoToNext()
    {
        Debug.Log("Next state");
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.GetComponent<ITarget>();
        col?.OnEnter(this);
    }
}
