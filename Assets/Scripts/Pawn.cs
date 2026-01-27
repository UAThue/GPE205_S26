using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    protected Mover mover;

    [HideInInspector] public Controller controller;
    public abstract void Move(Vector3 directionToMove);
    public abstract void Rotate(Vector3 directionToRotate);

    public abstract void Shoot();

    public float moveSpeed;
    public float turnSpeed;
    public Controller GetController () { return controller; }

    public void Start()
    {
        // Get the mover component
        mover = GetComponent<Mover>();
    }
}
