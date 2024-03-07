using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchVelocity = 0.1f;
    public float fireInterval = 1f; // Interval between shots in seconds

    private bool canFire = true;

    public AudioClip fire1;
    public AudioClip fire2;
    public AudioSource firesoruce;


    void Start()
    {
        // Call the FireProjectile method repeatedly with the specified interval
        InvokeRepeating("FireProjectile", 0f, fireInterval);
    }

    void FireProjectile()
    {
        // Check if the cannon can fire
        if (!canFire)
            return;

        int i = Random.Range(0, 2);

        if (i == 0)
        {
            firesoruce.clip = fire1;
        }
        else
        {
            firesoruce.clip = fire2;
        }

        firesoruce.Play();

        // Calculate the target position in front of the cannon
        Vector3 targetPosition = transform.position + transform.forward * 10f; // Adjust the distance as needed

        // Instantiate a new projectile at the cannon's position
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the velocity of the projectile towards the target position
        Vector3 direction = (targetPosition - transform.position).normalized;
        newProjectile.GetComponent<Rigidbody>().velocity = direction * launchVelocity;

        // Set canFire to false only after successfully firing a projectile
        canFire = false;
    }

    void LateUpdate()
    {
        // Reset canFire after a delay (fireInterval) to allow firing again
        if (!canFire)
        {
            Invoke("ResetFire", fireInterval);
        }
    }

    void ResetFire()
    {
        canFire = true;
    }
}
