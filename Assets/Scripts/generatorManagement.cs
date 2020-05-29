using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorManagement : MonoBehaviour
{
    public GameObject generator, text;
    public bool electricityUp;
    void Start()
    {
        generator.gameObject.SetActive(true);
        electricityUp = true;
        text.SetActive(false);
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
