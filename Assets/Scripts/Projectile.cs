using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool passedPlayer = false;
    private Transform playerTransform;
    public AudioClip impact1;
    public AudioClip impact2;
    public AudioClip impact3;
    public AudioSource source;

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
            int i = Random.Range(0, 3);
            if (i == 0)
            {
                source.clip = impact1;
            }else if(i == 1)
            {
                source.clip = impact2;
            }
            else
            {
                source.clip= impact3;
            }

            source.Play();

            MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();

            render.enabled = false;
            // Handle player collision (e.g., kill the player)
            //Destroy(other.gameObject); // Destroy the player
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
