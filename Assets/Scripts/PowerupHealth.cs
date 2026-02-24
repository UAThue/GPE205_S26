using UnityEngine;

[System.Serializable]
public class PowerupHealth : Powerup
{
    public float amountToHeal;

    public override void Apply(Pawn target)
    {
        // TODO: Heal the pawn in target.
        Debug.Log("HEALED!");
    }

    public override void Remove(Pawn target)
    {
        // TODO: Nothing. We don't do anything when removing a healing powerup.
    }

}
