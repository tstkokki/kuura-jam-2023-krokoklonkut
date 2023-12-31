using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    CameraControl valvontaKamerat;
    LoylynHeitto loyly;
    PortalControl portal;
    SuihkuControl suihku;

    InputCooldown loylyCooldown;

    private void Awake()
    {
        valvontaKamerat = GetComponent<CameraControl>();
        loyly = GetComponent<LoylynHeitto>();
        portal = GetComponent<PortalControl>();
        suihku = GetComponent<SuihkuControl>();
        loylyCooldown = GetComponent<InputCooldown>();

#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;

#endif
    }

    public void HeitaLoyly(InputAction.CallbackContext context)
    {
        if (IsPressed(context) && loylyCooldown.IsReady())
        {
            loyly.Heita();
            loylyCooldown.SetCooldown();
        }
    }

    public void ChangeCamera(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            valvontaKamerat.VaihdaKameraa((int)Mathf.Clamp(context.ReadValue<float>(),-1,1));

    }


    public void MuutaSuihkunLampoa(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            suihku.Adjust((int)context.ReadValue<float>());

    }


    public void Portaali1(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            portal.Aseta(0);
    }

    public void Portaali2(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            portal.Aseta(1);

    }

    public void Portaali3(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            portal.Aseta(2);

    }
    
    public void Pause(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("pause");

    }


    private static bool IsPressed(InputAction.CallbackContext context)
    {
        return context.performed && context.ReadValue<float>() != 0;
    }
}
