using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Tomas Gonzalez
public class MovingLaser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private bool movingToEnd = true;

    private void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
            if (transform.position == endPoint.position)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
            if (transform.position == startPoint.position)
                movingToEnd = true;
        }
    }
}
