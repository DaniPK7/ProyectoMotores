﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour
{
    AudioSource audioSource;
    //public float pitch;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print("Pasos: "+audioSource.isPlaying);

        if (Input.GetKey(KeyCode.Space)) { audioSource.Pause(); }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))       //If is moving
        {
            if (!audioSource.isPlaying) { audioSource.Play(); }
           
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (audioSource.pitch < 1.5f)
                {
                    audioSource.pitch += 0.0025f;
                }
                else if (audioSource.pitch >= 1.5f)
                {
                    audioSource.pitch = 1.5f;
                }
            }
            else
            {
                audioSource.pitch = 1f;
            }
        }
        else 
        {
            audioSource.Pause();
        }
    }
}
