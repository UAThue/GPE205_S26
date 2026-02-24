using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DamageOtherOnOverlap : MonoBehaviour
{
    public float damageDone;
    private Collider _collider;

    public void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        // Get the other object's health component
        Health otherHealth = other.GetComponent<Health>();
        // If it has one:
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        // Destroy this projectile
        Destroy(gameObject);
    }
}
