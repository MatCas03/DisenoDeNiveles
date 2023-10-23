using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPuerta : MonoBehaviour
{
    public int vidas = 3;
    public Renderer[] meshRenderers; // Array de los mesh renderers que se modificarán

    private Color colorNormal;
    private Color colorRojo25;
    private Color colorRojo60;

    public AudioSource audioPuerta;

    private void Start()
    {
        // Guarda los colores iniciales
        colorNormal = Color.white;
        colorRojo25 = Color.red * 0.5f;
        colorRojo60 = Color.red * 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala-enemigo"))
        {
            audioPuerta.Play();
            RestarVida();
        }
    }

    private void RestarVida()
    {
        vidas--;

        if (vidas <= 0)
        {
            DestruirGameObject();
        }
        else
        {
            ModificarColorMesh();
        }
    }

    private void ModificarColorMesh()
    {
        // Calcula el color según la cantidad de vidas restantes
        Color color;
        if (vidas == 2)
        {
            color = colorRojo25;
        }
        else if (vidas == 1)
        {
            color = colorRojo60;
        }
        else
        {
            color = colorNormal;
        }

        // Modifica el color de todos los mesh renderers
        foreach (Renderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }

    private void DestruirGameObject()
    {
        Destroy(gameObject);
    }
}
