using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDestruida : MonoBehaviour
{
    public GameObject targetGameObject;
    public AudioSource audioSource;
    public AudioClip soundClip;

    private bool soundPlayed = false;

    private void Update()
    {
        if (targetGameObject == null && !soundPlayed)
        {
            ReproducirSonidoUnaVez();
        }
    }

    private void ReproducirSonidoUnaVez()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
            soundPlayed = true;
        }
    }
}
