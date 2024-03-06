using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float baseSpeed = 8; // Base speed of the player
    public float baseHorizontalSpeed = 5; // Base horizontal speed of the player
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        if (!alive) return;

        // Calculate movement based on base speed and deltaTime
        Vector3 forwardMove = -transform.right * baseSpeed * Time.deltaTime; // Move along the negative x-axis
        forwardMove.y = 0; // Ignore the vertical component

        // Calculate horizontal movement only if there's input
        Vector3 horizontalMove = Vector3.zero;
        if (Input.acceleration.x != 0 || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 rotatedRight = Quaternion.Euler(-90, -90, 0) * transform.right;
            horizontalMove = (
                Input.acceleration.x +
                (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) -
                (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0)) *
                rotatedRight * baseHorizontalSpeed * Time.deltaTime;
        }

        Vector3 targetPosition = rb.position + forwardMove + horizontalMove;
        targetPosition.x = Mathf.Clamp(targetPosition.x, -5, 5);
        rb.MovePosition(targetPosition);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void IncreaseSpeed()
    {
        // Implement the logic to increase the player's speed here
        // For example, you can increase the baseSpeed variable
        // baseSpeed += 1;
    }

    public float GetSpeed()
    {
        return baseSpeed;
    }
}
