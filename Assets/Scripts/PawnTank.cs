using UnityEngine;

public class PawnTank : Pawn
{
    public override void Move(Vector3 directionToMove)
    {
        Debug.Log("Moving!");
    }

    public override void Rotate(Vector3 directionToRotate)
    {
        Debug.Log("Rotating!");
    }

    public override void Shoot()
    {
        // TODO: Shoot) 
        Debug.Log("Pew pew pew");
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
