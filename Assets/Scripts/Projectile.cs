using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    private bool passedPlayer = false;
    private Transform playerTransform;

    public AudioClip impact1;
    public AudioClip impact2;
    public AudioClip impact3;
    public AudioSource imparctsource;

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
                imparctsource.clip = impact1;
            }else if (i == 1)
            {
                imparctsource.clip = impact2;
            }
            else
            {
                imparctsource.clip= impact3;
            }

            imparctsource.Play();

            MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();

            render.enabled = false;

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

        // Ensure playerTransform is not null before accessing it
        if (playerTransform == null)
        {
            // Find the player object by tag again
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Get the player's transform
                playerTransform = player.transform;
            }
        }
    }
}
