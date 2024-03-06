using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnClose : MonoBehaviour
{
    PlayerMovement playerMovement;
    bool animationPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!animationPlayed) && Math.Abs(playerMovement.transform.position.z - transform.position.z) < 110){
            animationPlayed = true;
            GetComponent<Animator>().enabled = true;
        }
    }
}