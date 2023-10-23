using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControllerPelota : MonoBehaviour
{
    public GameObject objectToWatch; // The GameObject to watch for destruction
    public GameObject spawnObject; // The GameObject to spawn when objectToWatch is destroyed
    public GameObject spawnPositionObject; // The GameObject whose position will be used for spawning the new object
    public GameObject objectTodestroy;



    private bool hasSpawned = false; // Flag to track if the object has already spawned

    private void Update()
    {
        // Check if objectToWatch is destroyed and if the object has not already spawned
        if (objectToWatch == null && !hasSpawned)
        {
            // Set the flag to true to prevent spawning again
            hasSpawned = true;

            // Spawn a new object in the position of spawnPositionObject
            Instantiate(spawnObject, spawnPositionObject.transform.position, spawnPositionObject.transform.rotation);

            Destroy(objectTodestroy);
        }


    }
}

