using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedFence : MonoBehaviour
{
    public GameObject fence;
    private generatorManagement generator;
    private plierController plier;
    void Start()
    {
        generator = FindObjectOfType<generatorManagement>();
        plier = FindObjectOfType<plierController>();
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
                fence.gameObject.SetActive(false);
                plier.plierHUD.SetActive(false);
            }
        }
    }
}
