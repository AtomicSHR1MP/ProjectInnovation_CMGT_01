using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotSoundScript : MonoBehaviour
{

    public AudioClip sound;
    public AudioClip sound2;
    public AudioSource soundSource1;

    // Start is called before the first frame update
    void Start()
    {
        //  sound = GetComponent
        int i = Random.Range(0, 2);

        if (i > 0 ) {
            soundSource1.clip = sound2;

            soundSource1.Play();
        }
        else
        {
            soundSource1.clip = sound;
            soundSource1.Play();
        }
    



    }

    // Update is called once per frame
    void Update()
    {
      //  if(Time.deltaTime > 200)
      //  {
      //      soundSource1.clip = sound;
        //    soundSource1.Play();
        //}
    }
}
