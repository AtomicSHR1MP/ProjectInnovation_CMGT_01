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

        // Rotate the forward and right vectors by 90 degrees around the y-axis
        Vector3 rotatedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        Vector3 rotatedRight = Quaternion.Euler(0, -90, 0) * transform.right;

        rotatedForward = transform.forward;
        rotatedRight = transform.right;

        // Calculate movement based on base speed and deltaTime
        Vector3 forwardMove = rotatedForward * baseSpeed * Time.deltaTime;
        Vector3 horizontalMove = (
            Input.acceleration.x +
            (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) -
            (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0)) *
            rotatedRight * baseHorizontalSpeed * Time.deltaTime;
        
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
