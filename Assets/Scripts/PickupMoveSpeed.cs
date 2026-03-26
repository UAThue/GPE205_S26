using UnityEngine;

public class PickupMoveSpeed : Pickup
{
    public PowerupMoveSpeed powerup;
    
    public override void OnTriggerEnter(Collider other)
    {
        //Check if the other object has a PowerupManager;
        PowerupManager otherManager = other.GetComponent<PowerupManager>();

        if (otherManager != null)
        {
            // Add powerup
            otherManager.Add(powerup);

            // Destroy this object 
            Destroy(gameObject);
        }

        base.OnTriggerEnter(other);
    }
}
