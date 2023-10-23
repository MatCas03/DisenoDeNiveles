using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Axe : MonoBehaviour
{
    public float bounceDistance = 3f;
    public float bounceTime = 0.25f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {


            Vector3 direction = other.gameObject.transform.position - transform.position;

            direction.Normalize();
            Vector3 bounceBack = direction * bounceDistance;

            CharacterController playerController = other.gameObject.GetComponent<CharacterController>();
            StartCoroutine(BouncePlayer(playerController, bounceBack));

        }
    }
    IEnumerator BouncePlayer(CharacterController playerController, Vector3 bounceBack)
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
}
