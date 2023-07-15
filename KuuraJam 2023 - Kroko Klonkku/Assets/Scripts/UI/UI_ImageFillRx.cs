using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_ImageFillRx : MonoBehaviour
{
    [SerializeField]
    FloatVariable observed;
    [SerializeField]
    FloatVariable maxAmount;
    
    FloatReactiveProperty reactiveProperty;

    Image UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Image>();
        reactiveProperty = new FloatReactiveProperty(observed.Value);
        reactiveProperty.ObserveEveryValueChanged(v => observed.Value)
            .TakeUntilDisable(this)
            .Subscribe(s =>
            {
                FillImage();
            });
        FillImage();
    }

    private void FillImage()
    {
        UI.fillAmount = observed.Value / maxAmount.Value;
    }
}
