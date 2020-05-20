using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchlightManagement : MonoBehaviour
{
    public batteryManagement batterySC;
    Light torchlight;
    // Start is called before the first frame update
    void Start()
    {
        torchlight = GetComponent<Light>();
        //batterySC = GetComponent<batteryManagement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && batterySC.currentIndex <= 3)
        {
            batterySC.lanternOn = true;
            torchlight.enabled = true;
        }
        else 
        {
            batterySC.lanternOn = false;
            torchlight.enabled = false;
        }

    }
}
