using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorManagement : MonoBehaviour
{
    public GameObject generator;
    public bool electricityUp;
    void Start()
    {
        generator.gameObject.SetActive(true);
        electricityUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                print("No hay electricidad");
                generator.gameObject.SetActive(false);
                electricityUp = false;
            }
        }
    }
}
