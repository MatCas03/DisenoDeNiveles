using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonLv6 : MonoBehaviour
{
    public GameObject plataformaAActivar;
    public AudioSource audioSource;

    public ParticleSystem particulasLV6;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota2"))
        {
            plataformaAActivar.SetActive(true);
            audioSource.Play();
            particulasLV6.Play();
        }
    }
}

