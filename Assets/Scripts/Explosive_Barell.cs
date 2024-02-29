using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barell : MonoBehaviour
{

    public float knockbackForce = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Calculate the direction from the barrel to the player
                Vector3 directionToPlayer = other.transform.position - transform.position;

                // Apply knockback force instantly
                playerRigidbody.AddForce(directionToPlayer.normalized * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
