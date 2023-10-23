using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Imhotep Zumpano
public class PlatformGoAbove : MonoBehaviour
{
    public float teleportHeight = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPosition = other.transform.position + new Vector3(0f, teleportHeight, 0f);
            other.transform.position = newPosition;
        }
    }
}
