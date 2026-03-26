using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Level level;
    public CameraController cameraController;
    [Header("Prefabs")]
    public GameObject playerControllerPrefab;
    public GameObject playerPawnPrefab;
    [Header("Up-to-date Lists")]
    public List<Pawn> tanks;
    public List<Controller> players;
    public List<PlayerSpawn> playerSpawnPoints;

    void Awake()
    {
        // Create our singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Create our up to date list objects (not just memory locations, but actual lists)
        tanks = new List<Pawn>();
        players = new List<Controller>();
    }

    void Start()
    {
        // Start the Game!
        StartGame();

    }

    public void StartGame()
    {
        // Do everything we need to start the game
        // Generate the map
        level.mapGenerator.GenerateMap();

        // Spawn the player
        SpawnPlayer();

    }

    public void SpawnPlayer()
    {
        Vector3 playerSpawnPosition;
        // Choose a spawnpoint from the list
        if (playerSpawnPoints.Count > 0)
        {
            playerSpawnPosition = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position;             
        } else
        {
            playerSpawnPosition = Vector3.zero;
        }

            // Spawn a tank pawn (and store it in tempTankPawn)
            Pawn tempTankPawn = SpawnTank(playerPawnPrefab);

        // Spawn a player controller (and store it in players)
        Controller tempPlayerController = SpawnPlayerController(playerControllerPrefab);

        // Have the player possess the pawn
        tempPlayerController.Possess(tempTankPawn);

        // Move to spawnpoint
        tempTankPawn.transform.position = playerSpawnPosition;

        // Make the camera follow the player
        cameraController.lookTarget = tempTankPawn.transform;
    }

    public Pawn SpawnTank(GameObject prefab)
    {
        GameObject tempTankObject = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        return tempTankObject.GetComponent<Pawn>();
    } 
    
    public Controller SpawnPlayerController (GameObject prefab)
    {
        GameObject tempPlayer = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        return tempPlayer.GetComponent<Controller>();
    }

}
