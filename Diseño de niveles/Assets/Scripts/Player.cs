using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f; // Ajusta la sensibilidad del mouse

    private float rotationX = 0;

    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotación de la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}


