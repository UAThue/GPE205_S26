using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform lookTarget;
    public Vector3 localOffset;
    public float moveSpeed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldOffset = lookTarget.transform.TransformDirection(localOffset);
        Vector3 worldPosition = lookTarget.position + worldOffset;
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, moveSpeed * Time.deltaTime);
        transform.LookAt(lookTarget.position);      
    }
}
