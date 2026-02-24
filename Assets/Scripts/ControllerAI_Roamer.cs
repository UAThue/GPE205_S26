using UnityEngine;

public class ControllerAI_Roamer : ControllerAI
{

    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Idle:
                // PERFORM THE BEHAVIORS
                DoIdle();
                // CHECK FOR TRANSITIONS FOR THAT STATE
                break;
            case AIState.Roam:
                // PERFORM THE BEHAVIORS
                DoRoam();
                // CHECK FOR TRANSITIONS FOR THAT STATE
                break;
            case AIState.ChooseRoamDirection:
                // PERFORM THE BEHAVIORS
                // CHECK FOR TRANSITIONS FOR THAT STATE
                break;
            case AIState.Attack:
                // PERFORM THE BEHAVIORS

                // CHECK FOR TRANSITIONS FOR THAT STATE
                if ( !CanMoveForward(5) )
                {
                    ChangeState(AIState.Roam);
                }
                break;
        }

    }

    public void DoIdle()
    {
        //TODO: Whatever we do when idle
    }

    public void DoRoam()
    {
        // TODO: Rotate towards our roamDirection
        // TODO: Move Forward                
    }

}
