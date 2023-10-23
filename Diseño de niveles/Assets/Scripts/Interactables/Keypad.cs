using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Imhotep Zumpano
public class Keypad : Interactable
{   
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public AudioSource buttonSound1;
    public AudioSource buttonSound2;

    protected override void Interact()
    {

        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        if (buttonSound1 != null)
        {
            buttonSound1.Play();
        }
        if (buttonSound2 != null)
        {
            buttonSound2.Play();
        }

    }
}
