using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedFence : MonoBehaviour
{
    public GameObject fence, brokenFence;
    private generatorManagement generator;
    private plierController plier;
    void Start()
    {
        generator = FindObjectOfType<generatorManagement>();
        plier = FindObjectOfType<plierController>();
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
            if (!generator.electricityUp && Input.GetKeyDown(KeyCode.R) && plier.plierHUD.activeInHierarchy)
            {
                fence.SetActive(false);
                plier.plierHUD.SetActive(false);
                brokenFence.SetActive(true);
            }
        }
    }
}
