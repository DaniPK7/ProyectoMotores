using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedFence : MonoBehaviour
{
    public GameObject fence, brokenFence, text;
    private generatorManagement generator;
    private plierController plier;
    void Start()
    {
        generator = FindObjectOfType<generatorManagement>();
        plier = FindObjectOfType<plierController>();
        text.SetActive(false);
        brokenFence.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!generator.electricityUp && plier.plierHUD.activeInHierarchy)
            {
                text.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    text.SetActive(false);
                    fence.SetActive(false);
                    plier.plierHUD.SetActive(false);
                    brokenFence.SetActive(true);
                }
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
