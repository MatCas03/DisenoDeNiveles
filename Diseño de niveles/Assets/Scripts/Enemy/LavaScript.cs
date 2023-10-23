using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Teo Indomito
public class LavaScript : MonoBehaviour
{
    public Transform teleportLocation;
    private PlayerHealth playerHealth;

    [SerializeField]
    private bool isBurning;
    public float burnTime = 0.5f;
    private float burnTimer;
    private GameObject player;


    public AudioSource muerteJugador;
    public AudioSource audioSource;
    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            muerteJugador.Play();

            StartBurning();



            burnTimer += Time.deltaTime;
            if (burnTimer >= burnTime)
            {
                burnTimer = 0f;
                isBurning = false;

                TeleportPlayer();
                playerHealth.health = playerHealth.maxHealth;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopBurning();
        }
    }

    private void StartBurning()
    {

        isBurning = true;

    }

    private void StopBurning()
    {

        isBurning = false;

    }

    private void TeleportPlayer()
    {
        if (teleportLocation != null && player != null)
        {
            player.transform.position = teleportLocation.position;
        }
    }
}
