using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Mesh_Canonball;
    public Transform target;
    public float force;
    public float shootInterval = 1.5f; // Time between each automatic shot
    private float shootTimer = 0f;

    void Update()
    {
        // Count down the timer
        shootTimer -= Time.deltaTime;

        // If the timer reaches zero, shoot automatically
        if (shootTimer <= 0f)
        {
            Shoot();
            // Reset the timer to the shoot interval
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        // Instantiate the cannonball at the target's position and rotation
        GameObject bullet = Instantiate(Mesh_Canonball, target.position, target.rotation);

        // Get the Rigidbody component of the cannonball
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Apply force to the cannonball in the forward direction (disregard gravity)
        bulletRigidbody.velocity = target.forward * force;

        // Destroy the cannonball after a certain time to prevent FPS drop due to too many clones
        Destroy(bullet, 5f);
    }
}
