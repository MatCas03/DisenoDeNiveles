using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP2 - Teo Indomito
public class FreezeGun : MonoBehaviour
{
    public float damage = 0;
    public float range = 100f;
    public Transform gunEnd;
    public Material frozenMaterial;

    public GameObject impactEffect;

    static public bool ObjectIsFrozen = false;

    [SerializeField] private AudioSource audioSource;
    public LineRenderer laserLine;
    private Dictionary<GameObject, Material> originalMaterials = new Dictionary<GameObject, Material>();

    private float timeSinceLastShot = 0f;

    void Start()
    {

        RaycastHit hit;
        if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, range))
        {
            Freezable objectFreezable = hit.transform.GetComponent<Freezable>();
            if (objectFreezable != null)
            {
                Renderer objectRenderer = objectFreezable.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    originalMaterials[objectRenderer.gameObject] = objectRenderer.material;
                }
            }
        }
    }

    void Update()
    {
        if (timeSinceLastShot >= 3f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }

    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Freezable objectFreezable = hit.transform.GetComponent<Freezable>();
            if (objectFreezable != null)
            {
                Rigidbody objectRigidbody = objectFreezable.GetComponent<Rigidbody>();
                if (objectRigidbody != null)
                {
                    objectRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    ObjectIsFrozen = true;
                }

                if (objectRigidbody != null)
                {
                    objectFreezable.GetComponent<Collider>().isTrigger = false;

                }

                Renderer objectRenderer = objectFreezable.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    originalMaterials[objectRenderer.gameObject] = objectRenderer.material;

                    objectRenderer.material = frozenMaterial;


                    StartCoroutine(ResetMaterial(objectRenderer.gameObject, objectRenderer, objectRigidbody));
                }
                GameObject particleEffect = Instantiate(impactEffect, hit.point, Quaternion.identity);
                Destroy(particleEffect, 1.5f);
                audioSource.Play();

                laserLine.enabled = true;
                laserLine.SetPosition(0, gunEnd.position);
                laserLine.SetPosition(1, hit.point);
                StartCoroutine(DisableRaycast(laserLine));
            }
        }
    }

    IEnumerator ResetMaterial(GameObject objectToReset, Renderer objectRenderer, Rigidbody objectRigidbody)
    {
        yield return new WaitForSeconds(5f);
        objectRenderer.material = originalMaterials[objectToReset];
        objectRigidbody.constraints = RigidbodyConstraints.None;
        ObjectIsFrozen = false;
    }

    IEnumerator DisableRaycast(LineRenderer laserLine)
    {
        yield return new WaitForSeconds(1f);
        laserLine.enabled = false;
    }

}