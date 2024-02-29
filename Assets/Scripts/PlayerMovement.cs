using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;
    public float maxSpeed = 20;
    public float speedIncreasePerPoint = 0.001f;
    

    private void FixedUpdate()
    {
        if (!alive) return;

        // Calculate movement
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = Input.acceleration.x * transform.right * speed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + forwardMove + horizontalMove;

        // Check if the speed exceeds the maximum speed threshold
        if ((newPosition - rb.position).magnitude / Time.fixedDeltaTime > maxSpeed)
        {
            // Calculate the movement direction at the maximum speed
            Vector3 direction = (newPosition - rb.position).normalized;
            newPosition = rb.position + direction * maxSpeed * Time.fixedDeltaTime;
        }

        // Move the player to the new position
        rb.MovePosition(newPosition);
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
