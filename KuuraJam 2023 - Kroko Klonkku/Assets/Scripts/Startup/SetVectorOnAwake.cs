using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVectorOnAwake : MonoBehaviour
{
    [SerializeField]
    Vector3Variable Target;

    [SerializeField]
    Vector3 Offset;
    private void Awake()
    {
        Target.Position = transform.position + Offset;
    }
}
