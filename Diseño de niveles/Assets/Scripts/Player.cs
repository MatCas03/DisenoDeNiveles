using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f; // Ajusta la sensibilidad del mouse
    public float maxCameraAngle = 90.0f; // El �ngulo m�ximo en el que la c�mara puede mirar hacia arriba

    private float rotationX = 0;

    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotaci�n de la c�mara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Actualiza la rotaci�n en el eje X
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxCameraAngle, maxCameraAngle);

        // Aplica rotaci�n en el eje Y al personaje
        transform.Rotate(Vector3.up * mouseX);

        // Aplica rotaci�n en el eje X a la c�mara
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Calcula la direcci�n en la que mira la c�mara y la aplica al movimiento del personaje
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraForwardNoY = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        Vector3 moveDirection = (cameraForwardNoY * vertical + Camera.main.transform.right * horizontal).normalized;

        // Aplica el movimiento en la direcci�n de la c�mara
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}



