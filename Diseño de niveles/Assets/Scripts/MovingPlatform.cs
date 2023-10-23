using UnityEngine;

//TP2 - Imhotep Zumpano
public class MovingPlatform : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform player = transform.Find("Player");
            if (player != null)
                player.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("FUIEAHGEUAIGHUAHGEEA");
            other.transform.parent = transform;
        }

        if (other.CompareTag("Cube"))
        {
            Debug.Log("EL CUBO ES CHILD");
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER NO ES MAS CHILD");
            other.transform.parent = null;
        }


        if (other.CompareTag("Cube"))
        {
            Debug.Log("El cubo NO eschild");
            other.transform.parent = null;
        }
    }


}