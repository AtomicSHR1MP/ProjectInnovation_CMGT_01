using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnClose : MonoBehaviour
{

    public AudioClip jaws;
    public AudioSource jawsSource;

    PlayerMovement playerMovement;
    bool animationPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        jawsSource.clip = jaws;
        playerMovement = FindObjectOfType<PlayerMovement>();
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!animationPlayed) && Math.Abs(playerMovement.transform.position.z - transform.position.z) < 110){
            animationPlayed = true;
           
                jawsSource.Play();
          
            GetComponent<Animator>().enabled = true;
        }
    }
}