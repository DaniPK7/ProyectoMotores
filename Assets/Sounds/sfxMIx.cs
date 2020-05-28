using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sfxMIx : MonoBehaviour
{
    public AudioMixer sfxMixer;
    // Start is called before the first frame update
    public void SetSFXlevel(float vol) 
    {
        sfxMixer.SetFloat("sfxVol", vol);
    }
}
