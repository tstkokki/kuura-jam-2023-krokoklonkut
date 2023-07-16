using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suihku : MonoBehaviour
{
    public GameEvent suihkuIsFree;
    public GameEvent suihkuIsOccupied;

    private MovementScript suihkuttelijanMovementScript;

    private SaunaUkkoLista suihkuUkot;
    public int suihkuUkkoThreshold = 5;
    public int minTemp = 10;
    public int maxTemp = 90;
    public int temperature = 50;
    public int suihkuAdjustValue = 10;
    public float suihkuTime = 100;
    private float suihkuTimer = 0;
    public Vector3Variable suihkuLocation;
    public Vector3Variable portalLocation;
    public Vector3Variable exit;

    private bool ukkoIn;
    
    private bool suihkuIsOn = true;
    
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
        int newValue = temperature + suihkuAdjustValue;
        if(newValue < maxTemp)
        {
            temperature = newValue;
        }
        else
        {
            temperature = maxTemp;
        }
    }
    public void suihkuMinus()
    {
        int newValue = temperature - suihkuAdjustValue;
        if (newValue > minTemp)
        {
            temperature = newValue;
        }
        else
        {
            temperature = minTemp;
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
            float suihkuValue = 100 * (temperature / 100f);
            suihkuTimer -= suihkuValue * Time.deltaTime;
        }
        else if(suihkuTimer <= 0 && ukkoIn){
            GetSuihkuttelijanMovementScript().EnableMovement();
            GetSuihkuttelijanMovementScript().SetGoal(portalLocation);
            ukkoIn = false;
            suihkuIsFree.Raise();
            
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

    private void OnTriggerEnter(Collider col)
    {
        print(col.gameObject.name);

        SetSuihkuttelijanMovementScript(col.gameObject.GetComponentInChildren<MovementScript>());
        if(GetSuihkuttelijanMovementScript() != null)
        {
            MovementScript suihkuMs = GetSuihkuttelijanMovementScript();
            suihkuIsOccupied.Raise();
            suihkuMs.DisableMovement();
            ukkoIn = true;
            suihkuTimer = suihkuTime;
        }
    }

}
