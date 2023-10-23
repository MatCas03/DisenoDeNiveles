using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Tomas Gonzalez
public class BalaEnemigo : MonoBehaviour
{
    public AudioSource audioPuerta;
    public AudioSource audioPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
