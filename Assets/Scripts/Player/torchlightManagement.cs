using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchlightManagement : MonoBehaviour
{
    public batteryManagement batterySC;
    Light torchlight; 
    public Light lightTo;
    
    // Start is called before the first frame update
    void Start()
    {
        torchlight = GetComponent<Light>();
        batterySC.lanternOn = false;

        //batterySC = GetComponent<batteryManagement>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Mouse0) && batterySC.currentIndex <= 3)
        {
            batterySC.lanternOn = true;
            torchlight.enabled = true;
            lightTo.enabled = true;
        }
        else 
        {
            batterySC.lanternOn = false;
            torchlight.enabled = false;
            lightTo.enabled = false;
        }*/
        if (Input.GetKeyDown(KeyCode.E) && batterySC.currentIndex <= 3)
        {
            batterySC.lanternOn = !batterySC.lanternOn;
            if (batterySC.lanternOn)
            {
                torchlight.enabled = true;
                lightTo.enabled = true;
            }
            else
            {
                torchlight.enabled = false;
                lightTo.enabled = false;
            }
        }

    }
}
