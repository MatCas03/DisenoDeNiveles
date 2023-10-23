using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Tomas Gonzalez
public class Enemigo : MonoBehaviour
{

    public AudioSource audioSource;

    public Transform player;
    public Transform spawnPointOrigen;
    public Transform spawnPointDestino;
    public GameObject balaPrefab;
    public float velocidadBala = 10f;
    public float tiempoVidaBala = 3f;
    public float tiempoSpawn = 1f;

    public float visionRange = 10f;
    public Transform lookAtPoint;
    private bool isPlayerInRange;

    private float shootingTimer;
    public float shootingInterval = 2f;

    private float tiempoUltimoSpawn;

    private void Start()
    {
        tiempoUltimoSpawn = Time.time;
    }

    private void Update()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingInterval && isPlayerInRange)
        {
            shootingTimer = 0f;
            audioSource.Play();
            SpawnearBala();
        }


        if (Vector3.Distance(transform.position, player.position) <= visionRange)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }

        if (isPlayerInRange)
        {
            transform.LookAt(lookAtPoint);

        }
        else
        {

        }



    }

    private void SpawnearBala()
    {
        GameObject balaGO = Instantiate(balaPrefab, spawnPointOrigen.position, Quaternion.identity);
        Rigidbody balaRB = balaGO.GetComponent<Rigidbody>();
        Destroy(balaGO, tiempoVidaBala);

        Vector3 direccion = (spawnPointDestino.position - spawnPointOrigen.position).normalized;
        balaRB.velocity = direccion * velocidadBala;
    }
}
