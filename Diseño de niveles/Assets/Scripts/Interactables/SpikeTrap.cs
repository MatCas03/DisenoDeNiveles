using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private bool isPlayerInside;
    private bool isTriggered;
    private float activationDelay = 0.5f;
    private float destroyDelay = 1.5f;
    private bool isOnCooldown;
    private float cooldownDuration = 5f;
    private Coroutine cooldownCoroutine;

    // Reference to the spike object prefab
    public GameObject spikesPrefab;

    private void Update()
    {
        if (isPlayerInside && !isTriggered && !isOnCooldown)
        {
            // Start the activation delay
            StartCoroutine(ActivateSpikes());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Se estan x acitvar spikes");
            // Player enters the trigger area
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exits the trigger area
            isPlayerInside = false;
        }
    }

    private IEnumerator ActivateSpikes()
    {
        isTriggered = true;
        isOnCooldown = true;

        // Wait for the activation delay
        yield return new WaitForSeconds(activationDelay);

        // Instantiate the spikes
        GameObject spikes = Instantiate(spikesPrefab, transform.position, Quaternion.identity);


        Debug.Log("Spikes activated!");

        // Wait for the destroy delay
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the spikes
        Destroy(spikes);

        // Start the cooldown
        cooldownCoroutine = StartCoroutine(StartCooldown());
        isTriggered = false;
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
        cooldownCoroutine = null;
    }

    private void OnDestroy()
    {
        // Stop the cooldown coroutine if it's running
        if (cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
        }
    }
}
