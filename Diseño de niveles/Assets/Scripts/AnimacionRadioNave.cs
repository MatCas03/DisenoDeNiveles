using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Mateo Castares
public class AnimacionRadioNave : MonoBehaviour
{
    public Transform centro;
    public float radio = 5f;
    public float velocidad = 2f;

    private float angulo = 0f;

    private void Update()
    {

        float x = centro.position.x + Mathf.Cos(angulo) * radio;
        float y = centro.position.y + Mathf.Sin(angulo) * radio;


        transform.position = new Vector3(x, y, transform.position.z);

        angulo += velocidad * Time.deltaTime;

        if (angulo >= 2 * Mathf.PI)
        {
            angulo = 0f;
        }
    }
}
