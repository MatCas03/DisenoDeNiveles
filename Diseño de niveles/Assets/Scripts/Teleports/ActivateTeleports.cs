using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleports : MonoBehaviour
{
    public GameObject teleportToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            teleportToActivate.SetActive(true);
        }
    }
}
