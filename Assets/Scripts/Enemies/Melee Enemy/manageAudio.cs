using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class manageAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource [] wendigoSounds;
    [SerializeField]
    AudioClip[] wendigoClips ;
    // Start is called before the first frame update
    void Start()
    {
        //wendigoSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SetClip(int source, int clip) 
    {
       switch (clip)
        {
            case 0:
                wendigoSounds[source].clip = wendigoClips[0];
                wendigoSounds[source].volume = 0.7f;

                break;
            case 1:
                wendigoSounds[source].clip = wendigoClips[1];
                wendigoSounds[source].volume = 0.7f;

                break; 
            case 2:
                wendigoSounds[source].clip = wendigoClips[2];
                wendigoSounds[source].volume = 0.4f;

                break;

            default:
                break;
        }
        if (!wendigoSounds[source].isPlaying) wendigoSounds[source].Play();
    }
}
