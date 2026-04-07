using System.Collections.Generic;
using Unity.VisualScripting;
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
    [Header("Game Mode Objects")]
    public GameObject preMenuObject;
    public GameObject mainMenuObject;
    public GameObject settingsObject;
    public GameObject creditsObject;
    public GameObject gameplayObject;
    public GameObject gameOverObject; 

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

        // Name it to be easy to find in the hierarchy
        tempTankPawn.gameObject.name = "Player Pawn";

        // Set it's parent to be under the gameplay mode
        tempTankPawn.transform.parent = gameplayObject.transform;

        // Spawn a player controller (and store it in players)
        Controller tempPlayerController = SpawnPlayerController(playerControllerPrefab);

        // Have the player possess the pawn
        tempPlayerController.Possess(tempTankPawn);

        // Move to spawnpoint
        tempTankPawn.transform.position = playerSpawnPosition;

        // Add Audio Listener to player tank
        tempTankPawn.AddComponent<AudioListener>();

        // Make the camera follow the player
        cameraController.lookTarget = tempTankPawn.transform;
    }

    public Pawn SpawnTank(GameObject prefab)
    {
        GameObject tempTankObject = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        tempTankObject.transform.parent = gameplayObject.transform;
        return tempTankObject.GetComponent<Pawn>();
    } 
    
    public Controller SpawnPlayerController (GameObject prefab)
    {
        GameObject tempPlayer = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        tempPlayer.transform.parent = gameplayObject.transform;
        return tempPlayer.GetComponent<Controller>();
    }


    public void CloseAllGameModes()
    {
        preMenuObject.SetActive(false);
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(false);
        creditsObject.SetActive(false);
        gameOverObject.SetActive(false);
    }

    public void StartMainMenuMode()
    {
        CloseAllGameModes();
        mainMenuObject.SetActive(true);
    }

    public void StartSettingsMode()
    {
        CloseAllGameModes();
        settingsObject.SetActive(true);
    }

    public void StartCreditsMode()
    {
        CloseAllGameModes();
        creditsObject.SetActive(true);
    }

    public void StartGameplayMode()
    {
        CloseAllGameModes();
        gameplayObject.SetActive(true);
    }

    public void StartGameOverMode()
    {
        CloseAllGameModes();
        gameOverObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
