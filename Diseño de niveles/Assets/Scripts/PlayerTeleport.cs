using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Mateo Castares
public class PlayerTeleport : MonoBehaviour
{
    public AudioSource SonidoTP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teletransportador"))
        {
            SonidoTP.Play();

            TeleportPoint teleporter = other.GetComponent<TeleportPoint>();

            if (teleporter != null)
            {
                teleporter.TeleportPlayer(gameObject);
            }
        }
    }
}