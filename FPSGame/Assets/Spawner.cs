using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public Transform[] spawnPoints;  // Array of possible spawn points
    public float spawnInterval = 2f; // Time interval between spawns

    private bool isSpawning = false;

    // Method to start spawning
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }
    }

    // Method to stop spawning
    public void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            CancelInvoke("SpawnObject");
        }
    }

    // Method to spawn an object
    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(objectToSpawn, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}