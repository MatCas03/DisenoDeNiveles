using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2 - Tomas Gonzalez
public struct SensitivitySettings
{
    public float xSensitivity;
    public float ySensitivity;

    public SensitivitySettings(float xSensitivity, float ySensitivity)
    {
        this.xSensitivity = xSensitivity;
        this.ySensitivity = ySensitivity;
    }
}

//TP2 - Tomas Gonzalez
public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public SensitivitySettings sensitivitySettings = new SensitivitySettings(10f, 10f);
    public Slider slider;
    public Slider slidery;

    public void Start()
    {
        slider.value = sensitivitySettings.xSensitivity / 10;
        slidery.value = sensitivitySettings.ySensitivity / 10;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * sensitivitySettings.ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivitySettings.xSensitivity);
    }

    public void AdjustSpeedY(float newSpeed)
    {
        sensitivitySettings.ySensitivity = newSpeed * 10;
    }

    public void AdjustSpeedX(float newSpeed)
    {
        sensitivitySettings.xSensitivity = newSpeed * 10;
    }
}
