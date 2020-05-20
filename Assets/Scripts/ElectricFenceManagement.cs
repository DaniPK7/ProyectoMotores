using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFenceManagement : MonoBehaviour
{
    public GameObject fence;

    private healthbar healthbar;
    private generatorManagement generator;

    void Start()
    {
        healthbar = FindObjectOfType<healthbar>();
        generator = FindObjectOfType<generatorManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!generator.electricityUp)
        {
            Destroy(fence);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            healthbar.takeDamage(25);
        }
    }
}
