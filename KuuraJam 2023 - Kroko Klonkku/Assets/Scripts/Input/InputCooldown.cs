using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCooldown : MonoBehaviour
{
    [SerializeField]
    FloatVariable Cooldown;
    [SerializeField]
    FloatVariable Duration;


    // Update is called once per frame
    void Update()
    {
        if(Cooldown != null && Cooldown.Value > 0) 
        {
            Cooldown.Value -= Time.deltaTime;
        }
    }

    public bool IsReady()
    {
        return Cooldown.Value <= 0;
    }

    public void SetCooldown()
    {
        Cooldown.Value = Duration.Value;
    }
}
