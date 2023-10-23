using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parlante : Interactable
{
    /*[SerializeField]
    public GameObject musica;
    [SerializeField]
    private bool isOn = true;*/

    public AudioSource radioAudioSource;
    public AudioClip radioClip;
    public string message = "Presiona la tecla E para encender la radio";

    private bool radioOn = false;

    private void Start()
    {
        radioAudioSource.Stop(); // Asegúrate de que el audio de la radio esté detenido al iniciar
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!radioOn)
            {
                radioOn = true;
                radioAudioSource.clip = radioClip;
                radioAudioSource.Play();
                message = "Presiona la tecla E para apagar la radio";
            }
            else
            {
                radioOn = false;
                radioAudioSource.Stop();
                message = "Presiona la tecla E para encender la radio";
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), message);
    }



    /*protected override void Interact()
    {
        bool v = isOn = true;
        if (v)
        {
            gameObject.SetActive(false);
            isOn = false;
        }
        if (!v)
        {
            gameObject.SetActive(true);
            isOn = true;
        }


    }*/


}
