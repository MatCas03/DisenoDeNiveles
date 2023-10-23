using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    private void Start()
    {
        // Check if the current scene is "WinScene"
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "WinScene")
        {
            // Unlock the cursor and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
