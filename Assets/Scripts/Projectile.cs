using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan;
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
