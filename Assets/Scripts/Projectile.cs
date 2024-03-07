using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    private bool passedPlayer = false;
    private Transform playerTransform;
    PlayerMovement playerMovement;

    void Start()
    {
        // Find the player object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Get the player's transform
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collides with the player
        if (other.CompareTag("Player"))
        {
            // Kill the player
            playerMovement.Die();
            // Load the main menu scene
            SceneManager.LoadScene(0);
        }
    }

    void Update()
    {
        // If the player's position is ahead of the cannonball, mark as passed
        if (playerTransform != null && transform.position.z < playerTransform.position.z)
        {
            passedPlayer = true;
        }

        // If the projectile has passed the player, destroy it
        if (passedPlayer)
        {
            Destroy(gameObject);
        }
    }
}
