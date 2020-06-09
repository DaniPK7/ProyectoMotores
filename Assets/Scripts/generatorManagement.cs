using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorManagement : MonoBehaviour
{
    public GameObject generator, text, turnOffSFX;
    //public AudioSource turnOffSFX;
    public bool electricityUp;
    void Start()
    {
        generator.gameObject.SetActive(true);
        electricityUp = true;
        text.SetActive(false);
        turnOffSFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                text.SetActive(false);
                turnOffSFX.gameObject.SetActive(true);
                generator.gameObject.SetActive(false);
                electricityUp = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
