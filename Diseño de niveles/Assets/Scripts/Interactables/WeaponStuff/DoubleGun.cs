using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - Teo Indomito
public class DoubleGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePoint2;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private AudioSource audioSource;
    private List<GameObject> duplicateObjects = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && DoubleGunManager.Instance.CanShoot())
        {
            Shoot();
            DoubleGunManager.Instance.StartCooldown();
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(firePoint.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Duplicable duplicableScript = hit.transform.gameObject.GetComponent<Duplicable>();
            if (duplicableScript != null)
            {
                GameObject duplicatedObject = Instantiate(hit.transform.gameObject, hit.transform.position, hit.transform.rotation);
                duplicateObjects.Add(duplicatedObject);

                Rigidbody duplicatedRigidbody = duplicatedObject.GetComponent<Rigidbody>();
                if (duplicatedRigidbody != null)
                {
                    duplicatedRigidbody.isKinematic = false;
                }

                if (duplicateObjects.Count > 5)
                {
                    Destroy(duplicateObjects[0]);
                    duplicateObjects.RemoveAt(0);
                }

                Collider duplicatedCollider = duplicatedObject.GetComponent<Collider>();
                if (duplicatedCollider != null)
                {
                    duplicatedCollider.isTrigger = false;
                }
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
        }

        audioSource.Play();
    }
}
