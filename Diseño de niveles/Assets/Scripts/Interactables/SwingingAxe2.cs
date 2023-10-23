using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe2 : MonoBehaviour
{
    public float speed = 1.5f;
    public float limit = 75f;
    public bool randomStart = false;
    private float random = 0f;



    private void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0, 1);

        }
    }

    private void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

    }

}
