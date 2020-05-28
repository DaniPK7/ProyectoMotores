using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class manageAudio : MonoBehaviour
{

    AudioSource wendigoSounds;
    [SerializeField]
    AudioClip[] wendigoClips ;
    // Start is called before the first frame update
    void Start()
    {
        wendigoSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SetClip(int clip) 
    {
       switch (clip)
        {
            case 0:
                wendigoSounds.clip = wendigoClips[0];
                wendigoSounds.volume = 0.7f;

                break;
            case 1:
                wendigoSounds.clip = wendigoClips[1];
                wendigoSounds.volume = 0.7f;

                break; 
            case 2:
                wendigoSounds.clip = wendigoClips[2];
                wendigoSounds.volume = 0.4f;

                break;

            default:
                break;
        }
        if (!wendigoSounds.isPlaying) wendigoSounds.Play();
    }
}
