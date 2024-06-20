using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public Transform[] spawnPoints;  
    public float spawnInterval = 2f; 

    private bool isSpawning = false;

    
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }
    }

    
    public void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            CancelInvoke("SpawnObject");
        }
    }

    
    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(objectToSpawn, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}