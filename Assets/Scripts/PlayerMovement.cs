using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float baseSpeed = 20; // Base speed of the player
    public float baseHorizontalSpeed = 20; // Base horizontal speed of the player
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        if (!alive) return;

        // Rotate the forward and right vectors by 90 degrees around the y-axis
        Vector3 rotatedForward = Quaternion.Euler(0, -90, 0) * transform.forward;
        Vector3 rotatedRight = Quaternion.Euler(0, -90, 0) * transform.right;

        // Calculate movement based on base speed and deltaTime
        Vector3 forwardMove = rotatedForward * baseSpeed * Time.deltaTime;
        Vector3 horizontalMove = (
            Input.acceleration.x +
            System.Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)) -
            System.Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow))) *
            rotatedRight * baseHorizontalSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
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
        baseSpeed += 1;
    }

    public float GetSpeed()
    {
        return baseSpeed;
    }
}
