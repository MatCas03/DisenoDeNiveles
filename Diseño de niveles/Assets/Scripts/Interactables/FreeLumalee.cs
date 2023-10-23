using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLumalee : MonoBehaviour
{
    public GameObject lumaLeeHUB;

    public GameObject jaula;
    public AudioSource sonidoJaulaRota;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pelota")
        {
            sonidoJaulaRota.Play();
            jaula.SetActive(false);
            lumaLeeHUB.SetActive(true);
        }
    }
}
