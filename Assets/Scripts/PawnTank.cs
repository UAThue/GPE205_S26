using UnityEngine;

public class PawnTank : Pawn
{
    public override void Move(Vector3 directionToMove)
    {
        // Tell the mover to move
        mover.Move(directionToMove, moveSpeed);
    }

    public override void Rotate(Vector3 directionToRotate)
    {
        // Tell the mover to rotate
        mover.Rotate(directionToRotate, turnSpeed);
    }

    public override void Shoot()
    {
        // TODO: Shoot) 
        Debug.Log("Pew pew pew");
    }
}
