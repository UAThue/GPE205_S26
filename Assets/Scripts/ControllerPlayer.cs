using UnityEngine;

public class ControllerPlayer : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode turnRightKey;
    public KeyCode turnLeftKey;
    public KeyCode shootKey;
    public KeyCode reloadKey;

    public override void MakeDecisions()
    {
        //TODO: Write this function to make the decisions
        if (Input.GetKey(moveForwardKey))
        {
            pawn.Move(Vector3.forward);
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Move(-Vector3.forward);
        }
        if (Input.GetKey(turnRightKey))
        {
            pawn.Rotate(Vector3.right);
        }
        if (Input.GetKey(turnLeftKey))
        {
            pawn.Rotate(-Vector3.right);
        }



    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
