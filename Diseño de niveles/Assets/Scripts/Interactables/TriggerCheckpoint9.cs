using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint9 : MonoBehaviour
{
    private PlayerHealth playerHealth;

    // Specify the tag or the explicit object reference
    public string playerTag; // Set the tag in the Inspector or assign the object reference directly

    void Start()
    {
        // Find the PlayerHealth component in the specified object
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player object not found!");
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Make sure playerHealth is not null before accessing its properties
            if (playerHealth != null)
            {
                playerHealth.Checkpointlvl9 = true;
                
            }
            else
            {
                Debug.LogError("PlayerHealth component is missing!");
            }
        }
    }

    void Update()
    {
        // Check if playerHealth is not null before accessing its properties
        if (playerHealth != null)
        {
            Debug.Log(playerHealth.Checkpointlvl9);
        }
        else
        {
            Debug.LogError("PlayerHealth component is missing!");
        }
    }
}
