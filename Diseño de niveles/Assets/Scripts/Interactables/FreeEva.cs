using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeEva : MonoBehaviour
{
    public GameObject evaHUB;


    public GameObject jaulaEva;
    public AudioSource sonidoJaula2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Cube"))
        {
            sonidoJaula2.Play();
            jaulaEva.SetActive(false);

            evaHUB.SetActive(true);
        }
    }
}
