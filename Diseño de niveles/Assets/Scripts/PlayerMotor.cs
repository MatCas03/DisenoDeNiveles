using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Mateo Castares
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;
    public bool isGrounded;
    public float speed = 5f;
    public static float gravity = -9.8f;
    public float jumpHeight = 3f;

    //public AudioSource walkingSound;
    private bool isWalking;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        //if (walkingSound != null)
        //{
        //    walkingSound.loop = true;
        //    walkingSound.playOnAwake = false;
        //}
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && controller.velocity.magnitude > 0f)
        {
            if (!isWalking)
            {
                isWalking = true;
                //walkingSound.Play();
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                //walkingSound.Stop();
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

}