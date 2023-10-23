using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPelota : MonoBehaviour
{
    private bool isColliding;
    public GameObject posicionPelota;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            Debug.Log("Collision with Pelota");
            isColliding = true;
            other.gameObject.transform.position = posicionPelota.transform.position;
        }

    }
}
