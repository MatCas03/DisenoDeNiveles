using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public string playerTag = "Player";
    public float interactionRange = 3f;
    public AudioClip radioClip;

    private bool isInRange = false;
    private bool isPlaying = false;
    private AudioSource audioSource;
    private TextMesh messageText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        messageText = GetComponentInChildren<TextMesh>();

        messageText.text = "";
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isPlaying)
            {
                audioSource.clip = radioClip;
                audioSource.Play();
                isPlaying = true;

                messageText.text = "Press E to turn off the radio.";
            }
            else
            {
                audioSource.Stop();
                isPlaying = false;

                messageText.text = "Press E to turn on the radio.";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isInRange = true;

            messageText.text = "Press E to turn on the radio.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isInRange = false;

            messageText.text = "";
        }
    }
}
