using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerup : MonoBehaviour
{
    public float speedBoostMultiplier = 2f; 
    public float speedBoostDuration = 5f; 
    public float timeBetweenBoosts = 4f; 

    private bool isActivated = false; 
    private bool canReactivate = true; 

    private Vector3 originalScale; 
    private Vector3 originalPosition; 

   
    private PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = FindObjectOfType<PlayerMotor>();

        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canReactivate)
        {
            ActivateSpeedBoost();

            DeactivatePowerup();
        }
    }

    private void ActivateSpeedBoost()
    {
        playerMotor.speed *= speedBoostMultiplier;

        isActivated = true;

        StartCoroutine(RestoreSpeedAndReactivate());
    }

    private IEnumerator RestoreSpeedAndReactivate()
    {
        yield return new WaitForSeconds(speedBoostDuration);

        playerMotor.speed /= speedBoostMultiplier;

        yield return new WaitForSeconds(timeBetweenBoosts);

        canReactivate = true;

        transform.position = originalPosition;
        transform.localScale = originalScale;
    }

    private void DeactivatePowerup()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        canReactivate = false;

        StartCoroutine(ReactivatePowerup());
    }

    private IEnumerator ReactivatePowerup()
    {
        yield return new WaitForSeconds(timeBetweenBoosts);

        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;

        canReactivate = true;
    }
}
