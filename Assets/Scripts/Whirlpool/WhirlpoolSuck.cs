using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float pullForce = 10f; // Adjust this value to control the strength of the whirlpool
    public float whirlpoolRadius = 5f;
    public float treshold = 1f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Calculate the direction from the player to the center of the whirlpool
                Vector3 directionToCenter = transform.position - other.transform.position;

                // Calculate the distance from the player to the center of the whirlpool
                float distanceToCenter = directionToCenter.magnitude;

                // Check if the player is within the whirlpool radius
                if (distanceToCenter < whirlpoolRadius)
                {
                    // Normalize the direction to get a unit vector
                    directionToCenter.Normalize();

                    // Calculate the force magnitude based on distance and strength of the whirlpool
                    float forceMagnitude = pullForce / Mathf.Max(distanceToCenter, 0.1f);

                    // Apply the force in the opposite direction
                    playerRigidbody.AddForce(directionToCenter * forceMagnitude, ForceMode.Force);
                }

                if (distanceToCenter < treshold) // Adjust this value as needed
                {
                    // Destroy the player object
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Reset the player's velocity to prevent continuous force application
                playerRigidbody.velocity = Vector3.zero;
            }
        }
    }
}