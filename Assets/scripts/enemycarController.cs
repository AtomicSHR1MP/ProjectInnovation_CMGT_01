// EnemyCarController.cs
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    public float speed = 5f;



  

    void Start()
    {

    }

    void Update()
    {
        // Move the enemy car forward
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
}

