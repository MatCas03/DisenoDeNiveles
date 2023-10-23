using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2 - Mateo Castares
public class VolumeControl : MonoBehaviour
/*{
    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnVolumeSliderChanged(float volume)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.volume = volume;
        }
    }
}*/

{
    public Slider volumeSlider;

    // Define los valores mínimo y máximo del volumen deseado
    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;
    public float startVolume = 0.5f;

    private void Start()
    {
        // Asigna los valores mínimo y máximo al slider
        volumeSlider.minValue = minVolume;
        volumeSlider.maxValue = maxVolume;

        // Asigna el valor inicial del slider al volumen actual del audio
        volumeSlider.value = startVolume;

        // Registra el método OnSliderValueChanged para el evento OnValueChanged del slider
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Inicialmente, establece el volumen del juego al valor inicial del slider
        AudioListener.volume = startVolume;

        // Itera sobre todos los objetos con AudioSource y establece su volumen inicial
        foreach (AudioSource audioSource in FindObjectsOfType<AudioSource>())
        {
            audioSource.volume = startVolume;
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // Actualiza el volumen global del juego con el valor del slider
        AudioListener.volume = value;

        // Itera sobre todos los objetos con AudioSource y actualiza su volumen
        foreach (AudioSource audioSource in FindObjectsOfType<AudioSource>())
        {
            audioSource.volume = value;
        }
    }
}
