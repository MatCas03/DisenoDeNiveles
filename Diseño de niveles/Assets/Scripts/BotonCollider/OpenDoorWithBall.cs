using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Mateo Castares
public class OpenDoorWithBall : MonoBehaviour
{
    public GameObject door;
    public AudioSource audioSource;
    public GameObject cube;

    public ParticleSystem particulasBoton;

    [SerializeField]
    private bool doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            audioSource.Play();
            Debug.Log("Abrio la puerta.");
            cube.SetActive(true);
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
            particulasBoton.Play();
        }
    }
}
