using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Controller playerOne;
    public Pawn startPawn;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Have Player One connect to a pawn
        playerOne.Possess(startPawn);
    }
}
