using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed;
    private bool enableMovement = true;
    Vector3Variable goal;
    public Vector3Variable suihku;

    // Start is called before the first frame update
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (enableMovement && goal != null && transform.position != goal.Position)
        {
            float speed = moveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, goal.Position, speed);
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
