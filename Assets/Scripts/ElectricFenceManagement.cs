using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFenceManagement : MonoBehaviour
{
    public GameObject fence;
    public GameObject electricitySFX;

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
            Destroy(electricitySFX);
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
