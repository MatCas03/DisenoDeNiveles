using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private PlayerMotor playerMotor;
    public AudioSource footstepsSound;
    public AudioSource saltoSonidoEpico;

    private void Awake()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && playerMotor.isGrounded|| Input.GetKey(KeyCode.A) && playerMotor.isGrounded|| Input.GetKey(KeyCode.S) && playerMotor.isGrounded|| Input.GetKey(KeyCode.D) && playerMotor.isGrounded)
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && playerMotor.isGrounded)
        {
            saltoSonidoEpico.Play();
        }
    }
}
