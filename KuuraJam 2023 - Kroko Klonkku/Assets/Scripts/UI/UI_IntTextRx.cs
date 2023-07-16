using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class UI_IntTextRx : MonoBehaviour
{
    [SerializeField]
    IntVariable observed;

    IntReactiveProperty reactiveProperty;

    TextMeshProUGUI UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<TextMeshProUGUI>();
        if (UI != null)
        {

            reactiveProperty = new IntReactiveProperty(observed.Value);

            reactiveProperty.ObserveEveryValueChanged(v => observed.Value)
                .TakeUntilDestroy(this)
                .Subscribe(v =>
                {
                    PaivitaUI();
                });
            PaivitaUI();
        }

    }

    private void PaivitaUI()
    {
        UI.text = observed.Value.ToString();
    }
}
