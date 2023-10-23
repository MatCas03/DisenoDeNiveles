using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProximity : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform player;
    public float maxDistance = 10f;

    private float initialVolume;

    private void Start()
    {
        // Guardamos el volumen inicial del AudioSource
        initialVolume = audioSource.volume;
    }

    private void Update()
    {
        // Calculamos la distancia entre el AudioSource y el jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Calculamos el volumen en base a la distancia
        float volume = Mathf.Lerp(0f, initialVolume, 1f - Mathf.Clamp01(distance / maxDistance));

        // Actualizamos el volumen del AudioSource
        audioSource.volume = volume;

        // Reproducimos el audio en loop si no está sonando
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
