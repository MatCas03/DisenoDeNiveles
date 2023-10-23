using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDesaparece : MonoBehaviour
{
    public float deactivationTime = 2f; 
    public float reactivationTime = 2f; 

    private bool isActive = true;
    private float timer = 0f;

    private void Update()
    {

        timer += Time.deltaTime;

        if (isActive && timer >= deactivationTime)
        {
            DeactivatePlatform();
        }
        else if (!isActive && timer >= reactivationTime)
        {
            ReactivatePlatform();
        }
    }

    private void DeactivatePlatform()
    {
        gameObject.SetActive(false);
        isActive = false;

        timer = 0f;
        Invoke("ReactivatePlatform", reactivationTime);
    }

    private void ReactivatePlatform()
    {
        gameObject.SetActive(true);
        isActive = true;

        timer = 0f;
        Invoke("DeactivatePlatform", deactivationTime);
    }
}
