using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 3;


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player is Moving");
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World);

        // Move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }

        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }

    }

   
}
