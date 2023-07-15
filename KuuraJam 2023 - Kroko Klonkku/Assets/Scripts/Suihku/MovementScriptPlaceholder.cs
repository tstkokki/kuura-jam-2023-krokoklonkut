using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptPlaceholder : MonoBehaviour
{
    public float moveSpeed;
    private bool enableMovement = true;
    public Vector3Variable goal;
    public Vector3Variable suihku;

    // Start is called before the first frame update
    private void Start()
    {
        // Placeholder test thing
        goal = suihku;
    }
    // Update is called once per frame
    void Update()
    {
        if (enableMovement)
        {
            this.gameObject.transform.Translate(moveSpeed * Time.deltaTime * goal.Position);
        }
    }

    public void SuihkuIsOccupied()
    {
        print("occ");
        if(goal == suihku)
        {
            enableMovement = false;
        }
    }
    public void SuihkuIsFree()
    {
        print("free");
        if (goal == suihku)
        {
            enableMovement = true;
        }
    }

    public void EnableMovement()
    {
        enableMovement = true;
    }
    public void DisableMovement()
    {
        enableMovement = false;
    }

    public void SetGoal(Vector3Variable newGoal)
    {
        goal = newGoal;
    }

}
