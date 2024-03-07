using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayAnimOnClose : MonoBehaviour
{

    public AudioClip jaws;
    public AudioSource jawsSource;

    PlayerMovement playerMovement;
    bool animationPlayed = false;
    static bool isAudioPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        jawsSource.clip = jaws;
        playerMovement = FindObjectOfType<PlayerMovement>();
        GetComponent<Animator>().enabled = false;
        
        

    }

    void ChangeVariable()
    {
        isAudioPlaying = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isAudioPlaying) {
            jawsSource.Play();
            isAudioPlaying = true;
            Invoke("ChangeVariable", 13f);
        }
        
        if ((!animationPlayed) && Math.Abs(playerMovement.transform.position.z - transform.position.z) < 110){
            animationPlayed = true;
           
            
          
            GetComponent<Animator>().enabled = true;
        }
    }
}