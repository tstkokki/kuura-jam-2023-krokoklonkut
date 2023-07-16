using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIntVariableOnAwake : MonoBehaviour
{
    [SerializeField]
    IntVariable Variable;

    [SerializeField]
    int resetValue = 0;
    private void Awake()
    {
        if (Variable != null)
            Variable.Value = resetValue;
    }
}
