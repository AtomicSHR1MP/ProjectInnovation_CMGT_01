using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;
    public AudioClip clip;
    public AudioSource source;


    public void Start()
    {
        source.clip = clip;

    }

    public void OnTriggerEnter (Collider other)
    {
        /*  if (other.gameObject.GetComponent<Obstacle>() != null) {
              Destroy(gameObject);
              return;
          }
        */
        Console.WriteLine("coin collides with " + other.gameObject.name);
        // Check that the object we collided with is the player
         if (other.gameObject.name == "Player") {
            Console.WriteLine("coin plays sound " + other.gameObject.name);
            // Add to the player's score
            GameManager.inst.IncrementScore();

            source.clip = clip;

            source.Play();

            MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();

            render.enabled = false;


            // Destroy this coin object
            //  gameObject.SetActive(false);
            // Destroy(gameObject);
            return;
        }
       
        
      
    }

 

    private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}