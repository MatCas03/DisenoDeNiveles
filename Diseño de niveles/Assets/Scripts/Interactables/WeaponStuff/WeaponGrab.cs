using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//TP2 - Teo Indomito
public class WeaponGrab : MonoBehaviour
{

    public float grabRange = 30f;
    public float moveSpeed = 2f;
    public LayerMask grabbableLayer;
    public int pushStrength = 2000;

    public GameObject grabbedObject;
    public bool isGrabbing;
    private float distanceToGrabbedObject;

    public float maxDistanceToPlayer = 10f;
    public float minDistanceToPlayer = 3f;

    public ParticleSystem particulaGrab;

    private bool colisionAbajo = false;

    public ScriptGrabbed scriptGrabbed;

    public Image crosshairImage;

    [SerializeField] public AudioSource audioSourceGrabSFX;
    [SerializeField] public AudioSource audioSourceThrowSFX;

    private bool isParticlePlaying = false;



    private void ReverseIsTrigger(GameObject obj, bool isTrigger)
    {
        Collider[] colliders = obj.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.isTrigger = false;
        }
    }


    private void Update()
    {
        if (grabbedObject != null)
        {
            GrabTrigger grabTrigger = grabbedObject.GetComponent<GrabTrigger>();
            if (grabTrigger != null)
            {
                ReverseIsTrigger(grabbedObject, false);
                DropObject();

            }
        }

        /*if (grabbedObject != null)
        {
            if (scriptGrabbed != null)
            {
                Debug.Log("HEAODGJAEOIGA");
                if (scriptGrabbed.ShouldDropObject == true)
                {
                    Debug.Log(scriptGrabbed.ShouldDropObject);
                    DropObject();
                }
            }
        }*/

        if (grabbedObject == null || !grabbedObject)
        {
            grabbedObject = null;
            isGrabbing = false;

            if (isParticlePlaying)
            {
                particulaGrab.Stop();
                isParticlePlaying = false;
            }
        }


        if (grabbedObject != null)
        {
            Rigidbody grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRigidbody.constraints == RigidbodyConstraints.FreezeAll)
            {

                DropObject();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isGrabbing)
            {
                

                ReverseIsTrigger(grabbedObject, false);
                DropObject();

            }
            else
            {
                CheckForGrabbable();
            }
        }

        if (isGrabbing)
        {
            MoveObject();
        }

        if (grabbedObject != null)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                distanceToGrabbedObject = Mathf.Clamp(distanceToGrabbedObject - moveSpeed * Time.deltaTime, minDistanceToPlayer, maxDistanceToPlayer);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                distanceToGrabbedObject = Mathf.Clamp(distanceToGrabbedObject + moveSpeed * Time.deltaTime, minDistanceToPlayer, maxDistanceToPlayer);
            }

            Vector3 newPosition = transform.position + transform.forward * distanceToGrabbedObject;

            RaycastHit[] hits = Physics.RaycastAll(transform.position, newPosition - transform.position, Vector3.Distance(transform.position, newPosition), grabbableLayer);
            bool collisionDetected = false;

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject != grabbedObject)
                {
                    newPosition = hit.point;
                    distanceToGrabbedObject = Vector3.Distance(transform.position, newPosition);
                    collisionDetected = true;
                    break;
                }
            }

            if (!collisionDetected)
            {
                grabbedObject.transform.position = newPosition;
            }
        }

        if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.F)) && isGrabbing)
        {
            grabbedObject.transform.SetParent(null);
            grabbedObject.GetComponent<Collider>().enabled = true;

            Rigidbody grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRigidbody != null)
            {
                grabbedRigidbody.isKinematic = false;
            }
            ReverseIsTrigger(grabbedObject, false);
            grabbedObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushStrength);

            isGrabbing = false;
            grabbedObject = null;
            audioSourceThrowSFX.Play();

            if (isParticlePlaying)
            {
                particulaGrab.Stop();
                isParticlePlaying = false;
            }
        }
        UpdateCrosshairColor();

        distanceToGrabbedObject = Mathf.Clamp(distanceToGrabbedObject, minDistanceToPlayer, float.MaxValue);


        if (grabbedObject != null)
        {

            Collider[] grabbedColliders = grabbedObject.GetComponentsInChildren<Collider>();
            foreach (Collider collider in grabbedColliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
                {
                    collider.isTrigger = true;
                }
            }

            if (!isParticlePlaying)
            {
                particulaGrab.Play();
                isParticlePlaying = true;
            }
        }
        else
        {
            if (isParticlePlaying)
            {
                particulaGrab.Stop();
                isParticlePlaying = false;
            }
        }



    }




    private void FixedUpdate()
    {
        if (grabbedObject != null)
        {
            Transform grabbedTransform = grabbedObject.GetComponent<Transform>();

            Vector3 currentRotation = grabbedTransform.rotation.eulerAngles;

            currentRotation.x = 0f;
            currentRotation.z = 0f;

            grabbedTransform.rotation = Quaternion.Euler(currentRotation);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if (grabbedObject != null)
            {
                Transform grabbedTransform = grabbedObject.GetComponent<Transform>();

                grabbedTransform.rotation = Quaternion.Euler(Vector3.zero);
            }
        }

    }


    private void CheckForGrabbable()
    {
        RaycastHit hit;
        bool isGrabbableObjectInRange = false;

        if (Physics.Raycast(transform.position, transform.forward, out hit, grabRange, grabbableLayer))
        {
            grabbedObject = hit.transform.gameObject;

            Rigidbody grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRigidbody != null)
            {
                grabbedRigidbody.isKinematic = true;
            }

            distanceToGrabbedObject = Vector3.Distance(transform.position, grabbedObject.transform.position);

            grabbedObject.transform.SetParent(transform);
            grabbedObject.GetComponent<Collider>().enabled = true;

            // Add ScriptGrabbed script to grabbed object
            ScriptGrabbed scriptGrabbed = grabbedObject.GetComponent<ScriptGrabbed>();
            if (scriptGrabbed == null)
            {
                scriptGrabbed = grabbedObject.AddComponent<ScriptGrabbed>();
            }

            isGrabbing = true;
            isGrabbableObjectInRange = true;
        }

        if (isGrabbableObjectInRange)
        {
            audioSourceGrabSFX.Play();
        }
    }


    private void MoveObject()
    {
        grabbedObject.transform.position = transform.position + transform.forward * distanceToGrabbedObject;
    }

    public void DropObject()
    {
        // Remove ScriptGrabbed script from grabbed object
        ScriptGrabbed scriptGrabbed = grabbedObject.GetComponent<ScriptGrabbed>();
        if (scriptGrabbed != null)
        {
            Destroy(scriptGrabbed);
        }

        grabbedObject.transform.SetParent(null);
        grabbedObject.GetComponent<Collider>().enabled = true;

        Rigidbody grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
        if (grabbedRigidbody != null)
        {
            grabbedRigidbody.isKinematic = false;
        }

        isGrabbing = false;
        grabbedObject = null;

        if (isParticlePlaying)
        {
            particulaGrab.Stop();
            isParticlePlaying = false;
        }
    }



    private void UpdateCrosshairColor()
    {
        RaycastHit hit;
        bool hitGrabbableObject = Physics.Raycast(transform.position, transform.forward, out hit, grabRange, grabbableLayer);

        if (hitGrabbableObject)
        {
            if (hit.transform.gameObject == grabbedObject)
            {
                crosshairImage.color = new Color(0.0f, 0.5f, 0.0f);
            }
            else
            {

                crosshairImage.color = new Color(0.0f, 1.0f, 0.0f);
            }
        }
        else
        {
            crosshairImage.color = new Color(1.0f, 0.0f, 0.0f);
        }
    }

}