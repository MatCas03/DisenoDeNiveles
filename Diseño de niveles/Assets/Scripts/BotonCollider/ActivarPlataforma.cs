using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Imhotep Zumpano
public class ActivarPlataforma : MonoBehaviour
{
    public GameObject plataformaAActivar;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            plataformaAActivar.SetActive(true);
            audioSource.Play();
        }
    }
}
