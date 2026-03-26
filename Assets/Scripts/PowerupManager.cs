using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private Pawn pawn;

    public void Start()
    {
        // Get the pawn this PowerupManager is working with
        pawn = GetComponent<Pawn>();

        // Initialize the list of powerups
        powerups = new List<Powerup>();
    }

    public void Update()
    {
        // Update the countdown (lifespan) for every powerup
        UpdatePowerupLifespans();

        //Check for expired powerups and remove them
        CheckForExpiredPowerups();



        //TODO: TODO: WAY LATER - NOT IN THIS CLASS - this where you would check for and apply "over time" effects
    }

    public void UpdatePowerupLifespans()
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.lifespan -= Time.deltaTime;
        }
    }
    public void CheckForExpiredPowerups()
    {
        // First make a list of the powerups we need to remove
        List<Powerup> powerupsToRemove = new List<Powerup>();

        foreach (Powerup powerup in powerups)
        {
            if (powerup.lifespan <= 0)
            {
                powerupsToRemove.Add(powerup);
            }
        }

        // Then remove them from the (main) list
        // -- This way, you aren't iterating through the main list when you remove them
        foreach (Powerup powerup in powerupsToRemove)
        {
            Remove(powerup);
        }
    }


    public void Add(Powerup powerup)
    {
        // Apply the powerup's effects
        powerup.Apply(pawn);

        if (powerup.lifespan >= 0)
        {
            // Add it to our list
            powerups.Add(powerup);

            Debug.Log("");
        }
    }
    public void Remove(Powerup powerup)
    {
        // Remove the powerup's effects
        powerup.Remove(pawn);

        // Remove the powerup from the list
        powerups.Remove(powerup);       
    }
}
