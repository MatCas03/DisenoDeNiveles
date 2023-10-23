using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMouseBlock : MonoBehaviour
{
    private bool isMouseLocked = true;

    void Start()
    {
        LockUnlockMouse();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMouseLocked = !isMouseLocked;
            LockUnlockMouse();
        }
    }

    private void LockUnlockMouse()
    {
        if (isMouseLocked)
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
