using UnityEngine;

public class SpawnerTimed : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timeBetweenSpawns;
    public bool isSpawnOnStart;
    private float countdownTimer;
    private GameObject spawnedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set first spawn time
        if (isSpawnOnStart)
        {
            countdownTimer = 0;
        }
        else
        {
            countdownTimer = timeBetweenSpawns;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedObject == null)
        {
            // Subtract how much time has passed
            countdownTimer -= Time.deltaTime;

            // Check if our timer hit 0
            if (countdownTimer <= 0)
            {
                // Spawn object
                spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation) as GameObject;
                // Reset timer
                countdownTimer = timeBetweenSpawns;
            }
        }
    }
}
