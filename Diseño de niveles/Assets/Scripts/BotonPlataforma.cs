using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlataforma : MonoBehaviour
{
    public GameObject plataformaAActivar;
    public GameObject pelotaAActivar;
    public AudioSource audioSource;
    private bool AudioAdestruir = false;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
        
    {
        if (other.CompareTag("Player") && AudioAdestruir == false)
        {
            audioSource.Play();
            plataformaAActivar.SetActive(true);
            AudioAdestruir = true;
            Debug.Log(AudioAdestruir + " esta en true");
            pelotaAActivar.SetActive(true);
            
            
        }

    }
}
