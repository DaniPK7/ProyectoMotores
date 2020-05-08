using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickBattery : MonoBehaviour
{
    // Start is called before the first frame update
    batteryManagement batManag;
    void Start()
    {
        batManag = FindObjectOfType<batteryManagement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider item)
    {
        if (item.CompareTag("battery"))
        {
            if (batManag.batteryTimeLeft < batManag.maxBattery - 50)
            {
                batManag.batteryTimeLeft += 50;
                Destroy(item.gameObject);
            }
        }
    }
}
