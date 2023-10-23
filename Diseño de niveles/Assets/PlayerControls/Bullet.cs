using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // This script is attached to the bullet prefab and handles the bullet's movement and damage.
    public float speed = 10f;  // bullet speed
    public int damage = 10;   // bullet damage

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);  // move the bullet forward
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().currentHealth -= damage;  // reduce player's health
            if (other.GetComponent<PlayerController>().currentHealth <= 0)
            {
                Destroy(other.gameObject);  // destroy the player object if health is zero or below
            }
        }
        Destroy(gameObject);  // destroy the bullet object when it hits something
    }
}
