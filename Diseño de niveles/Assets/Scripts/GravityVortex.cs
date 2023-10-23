using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityVortex : MonoBehaviour
{
    public PlayerMotor playerMotor;
    public int PushStrenght = 20;

    private void Awake()
    {
        
        playerMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();

        if (playerMotor == null)
        {
            Debug.LogError("PlayerMotor not found on the player GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (playerMotor != null)
        {
            
            playerMotor.playerVelocity.y = Mathf.Sqrt(playerMotor.jumpHeight * - PushStrenght * PlayerMotor.gravity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // You can add any desired behavior for when the player exits the vortex here
    }
}
