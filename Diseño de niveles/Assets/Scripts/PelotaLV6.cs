using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaLV6 : MonoBehaviour
{
    public AudioSource audioSource;
    private Renderer cubeRenderer;
    public Color newColor = Color.red;
    private Color originalColor;
    private bool isColliding;

    public GameObject posicionPelota2;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
        isColliding = false;
    }

    private void Update()
    {
        if (isColliding)
        {
            StartCoroutine(ChangeColorCoroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            audioSource.Play();
            Debug.Log("Collision with Cube");
            isColliding = true;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Pelota2"))
        {
            audioSource.Play();
            Debug.Log("Collision with Pelota");
            isColliding = true;
            other.gameObject.transform.position = posicionPelota2.transform.position;
        }

    }

    private System.Collections.IEnumerator ChangeColorCoroutine()
    {
        cubeRenderer.material.color = newColor;
        yield return new WaitForSeconds(0.5f);
        cubeRenderer.material.color = originalColor;
        isColliding = false;
    }
}