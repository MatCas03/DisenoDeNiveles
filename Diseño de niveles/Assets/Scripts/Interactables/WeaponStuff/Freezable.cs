using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP2 - Teo Indomito
public class Freezable : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float timeSinceActivated;
    private bool constraintsActivated;
    public float waitTime = 5.3f;

    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            originalMaterials[renderer] = renderer.material;
        }
    }

    void Update()
    {
        if (rigidbody.constraints != RigidbodyConstraints.None && !constraintsActivated)
        {
            timeSinceActivated = Time.time;

            constraintsActivated = true;
        }

        if (constraintsActivated && Time.time - timeSinceActivated > waitTime)
        {
            rigidbody.constraints = RigidbodyConstraints.None;

            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = false;
            }

            constraintsActivated = false;

            FreezeGun.ObjectIsFrozen = false;

            foreach (Renderer renderer in originalMaterials.Keys)
            {
                renderer.material = originalMaterials[renderer];
            }
        }
    }
}