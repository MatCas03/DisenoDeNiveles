using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f; // Ajusta la sensibilidad del mouse
    public float maxCameraAngle = 90.0f; // El ángulo máximo en el que la cámara puede mirar hacia arriba

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

        // Actualiza la rotación en el eje X
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxCameraAngle, maxCameraAngle);

        // Aplica rotación en el eje Y al personaje
        transform.Rotate(Vector3.up * mouseX);

        // Aplica rotación en el eje X a la cámara
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Calcula la dirección en la que mira la cámara y la aplica al movimiento del personaje
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraForwardNoY = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        Vector3 moveDirection = (cameraForwardNoY * vertical + Camera.main.transform.right * horizontal).normalized;

        // Aplica el movimiento en la dirección de la cámara
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}



