using UnityEngine;


public enum AIState { ChooseRoamDirection, Roam, Attack, TurnAndShoot, Flee, Chase, Idle, Patrol }

public abstract class ControllerAI : Controller
{
    private Quaternion roamDirection = Quaternion.identity;
    protected float transitionChangeTime;
    protected AIState currentState = AIState.Roam;

    public override void Start()
    {
        // Save our transition time as when we started
        transitionChangeTime = Time.deltaTime;
    }

    public void ChangeState ( AIState newState )
    {
        // Change the state
        currentState = newState;
        // Save the time we changed states
        transitionChangeTime = Time.time;
    }


    public bool CanMoveForward ( float distance )
    {
        //TODO: Raycast forward for the distance we passed in
        //TODO: If that hits something, return false

        // Otherwise, return true
        return true;
    }

    public bool IsObjectInRange(Transform objectToCheck, float range)
    {
        // Find the distance between our pawn and the object we are checking
        if (Vector3.Distance(objectToCheck.position, pawn.transform.position) < range)
        {
            // If that is <range, return true
            return true;
        }

        // Otherwise, return false
        return false;
    }

    public bool IsRoamDirectionChosen ()
    {
        if (roamDirection != Quaternion.identity)
        {
            // If yes, return true
            return true;
        } else
        {
            // Otherwise, return false
            return false;
        }
    }

    public bool HasTimeElapsed (float seconds)
    {
        // If the current time minus the time we last changed is > the time we are waiting
        if (Time.time - transitionChangeTime >= seconds)
        {
            return true;
        } 

        // Otherwise, the time has not yet passed
        return false;
    }

}
