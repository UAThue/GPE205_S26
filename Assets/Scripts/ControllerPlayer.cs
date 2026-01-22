using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
    public InputActionAsset inputActions;

    public override void MakeDecisions()
    {
        // Write this function to make the decisions
        Vector2 movementVector = inputActions["Move"].ReadValue<Vector2>();
        pawn.Move(new Vector2(0, movementVector.y));
        pawn.Rotate(new Vector2(movementVector.x, 0));

        if (inputActions["Shoot"].triggered)
        {
            pawn.Shoot();
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Enable my input actions
        inputActions.Enable();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Do what the parent class (Controller) does on Update
        base.Update();
    }


}
