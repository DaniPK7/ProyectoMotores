using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinSounds : MonoBehaviour
{
    [SerializeField]
    AudioSource[] goblinSource;
    [SerializeField]
    AudioClip[] goblinClips;
    // Start is called before the first frame update
    void Start()
    {
        //goblinSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SetClip(int source, int clip)
    {
        print("Goblin "+ this.name+"con audio source "+ goblinSource[source].name);
        switch (clip)
        {
            case 0:
                goblinSource[source].loop = true;

                goblinSource[source].clip = goblinClips[0];     //Idle
                goblinSource[source].volume = 0.7f;
                if (!goblinSource[source].isPlaying) goblinSource[source].Play();



                break;
            case 1:
                goblinSource[source].loop = true;

                goblinSource[source].clip = goblinClips[1];     //Atack
                goblinSource[source].volume = 0.7f;
                if (!goblinSource[source].isPlaying) goblinSource[source].Play();



                break;
            case 2:
                goblinSource[source].clip = goblinClips[2];     //Death
                goblinSource[source].volume = 0.7f;
                if (!goblinSource[source].isPlaying) goblinSource[source].Play();


                goblinSource[source].loop = false;

                break;

            default:
                goblinSource[source].loop = true;

                break;
        }
       // if (!goblinSource.isPlaying) goblinSource.Play();
    }
}
