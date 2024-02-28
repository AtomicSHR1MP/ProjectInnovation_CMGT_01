using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration = 10f; // Acceleration factor
    public float maxSpeed = 20f; // Maximum speed of the car
    public float maxPosX = 2f; // Maximum position on the X-axis
    public float minPosX = -2f; // Minimum position on the X-axis
    public float maxPosZ = 2f; // Maximum position on the Z-axis
    public float minPosZ = -2f; // Minimum position on the Z-axis
    public float forwardSpeed = 5f; // Forward speed of the car
    private Vector3 position; // Current position of the car

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        // Calculate acceleration based on accelerometer input
        float accelerationInputX = Input.acceleration.x;
        float accelerationInputY = Input.acceleration.y;

        // Adjust the current speed based on acceleration
        float currentSpeedX = Mathf.Clamp(accelerationInputX * acceleration, -maxSpeed, maxSpeed);
        float currentSpeedZ = Mathf.Clamp(accelerationInputY * acceleration, -maxSpeed, maxSpeed);

        // Update the position based on the current speed and forward speed
        position += new Vector3(currentSpeedX, 0, currentSpeedZ + forwardSpeed) * Time.deltaTime;

        // Clamp the car's position within the specified range
        position.x = Mathf.Clamp(position.x, minPosX, maxPosX);
        position.z = Mathf.Clamp(position.z, minPosZ, maxPosZ);

        // Update the car's position
        transform.position = position;

        Debug.Log(position);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
        }
    }
}