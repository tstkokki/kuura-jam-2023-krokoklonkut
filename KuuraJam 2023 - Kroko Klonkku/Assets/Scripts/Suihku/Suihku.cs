using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suihku : MonoBehaviour
{
    private MovementScript suihkuttelijanMovementScript;

    private SaunaUkkoLista suihkuUkot;
    public int suihkuUkkoThreshold = 5;
    public int minTemp = 10;
    public int maxTemp = 90;
    public IntVariable temperature;
    public int suihkuAdjustValue = 10;
    public float suihkuTime = 100;
    public float suihkuTimer = 0;
    public Vector3Variable suihkuLocation;
    public Vector3Variable portalLocation;
    public Vector3Variable exit;
    public Vector3Variable suihkuInnerLocation;

    private bool ukkoIn;
    
    private bool suihkuIsOn = true;

    [SerializeField]
    SaunaPalvelu palvelu;
    
    public void AddSuihkuUkko(SaunaUkko ukko)
    {
        suihkuUkot.AddUkko(ukko);
        MovementScript ukkoMovement = ukko.gameObject.GetComponentInChildren<MovementScript>();
        if (suihkuUkot.Count > suihkuUkkoThreshold)
        {
            ukkoMovement.SetGoal(exit);
        }
        else
        {
            ukkoMovement.SetGoal(suihkuLocation);
        }
    }
    public void RemoveSuihkuUkko(SaunaUkko ukko)
    {
        suihkuUkot.RemoveUkko(ukko);
    }

    public void SetSuihku(bool state){
        suihkuIsOn = state;
    }
    public void ToggleSuihku()
    {
        if (suihkuIsOn)
        {
            suihkuIsOn = false;
        }
        else
        {
            suihkuIsOn = true;
        }
    }
    public bool IsSuihkuOn()
    {
        return suihkuIsOn;
    }

    public void suihkuPlus()
    {
        int newValue = temperature.Value + suihkuAdjustValue;
        if(newValue < maxTemp)
        {
            temperature.Value = newValue;
        }
        else
        {
            temperature.Value = maxTemp;
        }
    }
    public void suihkuMinus()
    {
        int newValue = temperature.Value - suihkuAdjustValue;
        if (newValue > minTemp)
        {
            temperature.Value = newValue;
        }
        else
        {
            temperature.Value = minTemp;
        }
    }

    // Kaikkien lempi update, en nyt muista miten timescalet ym. toimi coroutineiden ym kaa
    private void Update()
    {
        CheckSuihkuTimer();
    }

    public void CheckSuihkuTimer() {
        if (suihkuIsOn && suihkuTimer > 0)
        {
            float suihkuValue = 100 - temperature.Value;
            suihkuTimer -= suihkuValue * Time.deltaTime;
        }
        else if(suihkuTimer <= 0 && ukkoIn){
            GetSuihkuttelijanMovementScript().SetGoal(portalLocation);
            ukkoIn = false;
            palvelu.PoistuSuihkusta(GetSuihkuttelijanMovementScript().GetComponent<SaunaUkko>());
            SaunaUkko sukko = GetSuihkuttelijanMovementScript().GetComponent<SaunaUkko>();
            SpriteRenderer sr = sukko.GetComponentInChildren<SpriteRenderer>();
            if (sr != null){
                sr.flipX = false; }
        }
    }

    public void SetSuihkuttelijanMovementScript(MovementScript movementScript)
    {
        suihkuttelijanMovementScript = movementScript;
    }
    public MovementScript GetSuihkuttelijanMovementScript()
    {
        return suihkuttelijanMovementScript;
    }

    private void OnTriggerStay(Collider col)
    {
        //print(col.gameObject.name);

        if(GetSuihkuttelijanMovementScript() != col.GetComponentInChildren<MovementScript>() && !ukkoIn)
        {
            SetSuihkuttelijanMovementScript(col.gameObject.GetComponentInChildren<MovementScript>());
            GetSuihkuttelijanMovementScript().SetGoal(suihkuInnerLocation);
            ukkoIn = true;
            suihkuTimer = suihkuTime;
        }
    }

    private void Start()
    {
        temperature.Value = 50;
    }
}
