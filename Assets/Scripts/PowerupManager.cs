using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private Pawn pawn;

    public void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    public void Update()
    {
        //TODO: Check for expired powerups and remove them
        //TODO: TODO: WAY LATER - NOT IN THIS CLASS - this where you would check for and apply "over time" effects
    }

    public void Add(Powerup powerup)
    {
        // Apply the powerup's effects
        powerup.Apply(pawn);

        // Add it to our list
        powerups.Add(powerup);
    }
    public void Remove(Powerup powerup)
    {
        // Remove the powerup's effects
        powerup.Remove(pawn);

        // Remove the powerup from the list
        powerups.Remove(powerup);       
    }
}
