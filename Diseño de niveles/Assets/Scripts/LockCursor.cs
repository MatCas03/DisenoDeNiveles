using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    private bool cursorLocked = true;

    private void Update()
    {
        // Verifica si se presionó la tecla Esc para desbloquear el cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = false;
        }

        // Verifica si se hizo clic en la ventana del juego para bloquear el cursor
        if (Input.GetMouseButtonDown(0))
        {
            cursorLocked = true;
        }

        // Bloquea o desbloquea el cursor según el estado
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

