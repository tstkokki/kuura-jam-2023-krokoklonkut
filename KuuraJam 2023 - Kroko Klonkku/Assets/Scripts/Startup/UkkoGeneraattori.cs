using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkkoGeneraattori : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    SaunaUkkoLista lista;

    public int UkkoPerSauna = 5;

    int[] Hps = new int[3] { 80, 50, 120 };
    int[] Res = new int[3] { 20, 5, 40 };
    float[] Speeds = new float[3] { 1, 1.5f, 1.2f };

    private void Awake()
    {

        for (int i = 0; i < UkkoPerSauna; i++)
        {
            var obj = Instantiate(prefab);
            obj.transform.position = transform.position;
            var ukko = obj.GetComponent<SaunaUkko>();
            ukko.Init(
                Hps[Random.Range(0, Hps.Length)],
                Res[Random.Range(0, Res.Length)],
                Speeds[Random.Range(0, Speeds.Length)]
                );
            lista.AddUkko(ukko);
        }

    }

}
