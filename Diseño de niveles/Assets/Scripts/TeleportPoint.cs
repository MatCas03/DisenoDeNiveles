using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Mateo Castares
public class TeleportPoint : MonoBehaviour
{
    public Transform teleportPoint;

    public void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportPoint.position;
    }
}
