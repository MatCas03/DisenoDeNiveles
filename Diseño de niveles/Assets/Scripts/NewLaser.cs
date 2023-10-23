using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaser : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;

    public AudioSource audioSource;

    public float bounceDistance = 3f;
    public float bounceTime = 0.25f;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    private IEnumerator BouncePlayer(CharacterController playerController, Vector3 bounceBack)
    {
        Vector3 originalPosition = playerController.transform.position;
        Vector3 endPosition = originalPosition + bounceBack;

        float distance = Vector3.Distance(originalPosition, endPosition);
        float speed = distance / bounceTime;

        float t = 0f;
        while (t < bounceTime)
        {
            t += Time.deltaTime;
            float progress = t / bounceTime;
            playerController.Move(Vector3.Lerp(originalPosition, endPosition, progress) - playerController.transform.position);
            yield return null;
        }
    }

    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.tag == "Player")
            {
                audioSource.Play();

                Vector3 direction = hit.transform.position - transform.position;
                direction.Normalize();
                Vector3 bounceBack = direction * bounceDistance;

                CharacterController playerController = hit.transform.GetComponent<CharacterController>();
                StartCoroutine(BouncePlayer(playerController, bounceBack));

                PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(3);
                }
            }
        }
        else lr.SetPosition(1, transform.up * 5000);
    }
}
