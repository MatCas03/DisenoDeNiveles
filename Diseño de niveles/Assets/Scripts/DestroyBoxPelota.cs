using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Tomas Gonzalez
public class DestroyBoxPelota : MonoBehaviour
{
    public AudioSource audioSource;
    private Renderer cubeRenderer;
    public Color newColor = Color.red;
    private Color originalColor;
    private bool isColliding;

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
        if (other.CompareTag("Pelota"))
        {
            audioSource.Play();
            Debug.Log("Collision with Cube");
            isColliding = true;
            other.gameObject.SetActive(false);
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


