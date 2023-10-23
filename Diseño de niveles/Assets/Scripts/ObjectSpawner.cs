using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Tomas Gonzalez
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius;

    private void Update()
    {
        
        if (!ObjectExistsWithTag("Cube", spawnRadius))
        {
            
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }

    private bool ObjectExistsWithTag(string tag, float radius)
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }

        return false;
    }
}
