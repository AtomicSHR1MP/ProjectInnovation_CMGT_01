// TrackMove.cs
using UnityEngine;

public class TrackMove : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 offset = Vector2.zero;

    void Update()
    {
        // Calculate the texture offset based on time and speed
        offset.y += speed * Time.deltaTime;

        // Apply the offset to the material's main texture
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
