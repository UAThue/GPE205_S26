[System.Serializable]
public abstract class Powerup
{
    public abstract void Apply(Pawn target);
    public abstract void Remove(Pawn target);
}
