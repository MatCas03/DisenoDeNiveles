using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Teo Indomito
public class WeaponMovement : MonoBehaviour
{
    public float moveAmount = 0.1f; 
    public float moveSpeed = 10f; 

    public float moveAmountStanding = 0.1f; 
    public float moveSpeedStanding = 10f; 
    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float x = Mathf.Sin(Time.time * moveSpeed) * moveAmount;
            float y = Mathf.Cos(Time.time * moveSpeed * 2f) * moveAmount;
            transform.localPosition = originalPos + new Vector3(0f, y, x);
        }
        else
        {
            float x = Mathf.Sin(Time.time * moveSpeedStanding) * moveAmount;
            float y = Mathf.Cos(Time.time * moveSpeedStanding * 2f) * moveAmount;
            transform.localPosition = originalPos + new Vector3(0f, y, x);
        }
    }
}
