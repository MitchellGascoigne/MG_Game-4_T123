using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject objectToSpawn; // The game object to spawn
    public Transform[] spawnPoints; // The three spawn points
    public float waitTime = 3f; // The time between each spawn

    private GameObject spawnedObject; // The spawned game object

    void Start()
    {
        // Call the SpawnObject method after the wait time
        Invoke("SpawnObject", waitTime);
    }

    void SpawnObject()
    {
        // If the spawned object exists, destroy it
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the game object at the chosen spawn point
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Call the SpawnObject method after the wait time
        Invoke("SpawnObject", waitTime);
    }
}

