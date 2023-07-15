using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    public void HeitaLoyly(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("Heitä löylyä");
    }

    private static bool IsPressed(InputAction.CallbackContext context)
    {
        return context.performed && context.ReadValue<float>() != 0;
    }

    public void ChangeCamera(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log($"Muuta kamera {context.ReadValue<float>()}");

    }


    public void MuutaSuihkunLampoa(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log($"Muuta suihkua {context.ReadValue<float>()}");

    }


    public void Portaali1(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("Portaali 1");
    }

    public void Portaali2(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("Portaali 2");

    }

    public void Portaali3(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("Portaali 3");

    }
    
    public void Pause(InputAction.CallbackContext context)
    {
        if (IsPressed(context))
            Debug.Log("Portaali 3");

    }

}
