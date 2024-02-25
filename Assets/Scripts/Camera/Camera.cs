using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 1f, -10f); // Offset to adjust the camera position relative to the player

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to be the same as the player's position plus the offset
            transform.position = target.position + offset;

            // Make the camera look at the player
            transform.LookAt(target.position);
        }
    }
}