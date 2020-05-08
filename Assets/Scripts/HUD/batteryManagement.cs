using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batteryManagement : MonoBehaviour
{
    public int batteryTimeLeft; 
    public int maxBattery;

    [SerializeField]
    List<Texture> batteryImages;

    int currentIndex;
    bool lanternOn;

    private RawImage currentImage;

    // Start is called before the first frame update
    void Start()
    {
        lanternOn = true;
        maxBattery = 200;
        batteryTimeLeft = maxBattery;
        currentIndex = 0;
        currentImage = GetComponent<RawImage>();
        InvokeRepeating("setBatteryTimeLeft", 1f, 1f);
    }

    void setBatteryTimeLeft()
    {
        if (lanternOn)
            batteryTimeLeft--;
        if (batteryTimeLeft < 0)
            batteryTimeLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryTimeLeft>=150) 
            currentIndex = 0;
        else if (batteryTimeLeft>=100)
            currentIndex = 1;
        else if (batteryTimeLeft>=50)
            currentIndex =2;
        else if (batteryTimeLeft > 0)
            currentIndex = 3;
        else
            currentIndex = 4;
        currentImage.texture =  batteryImages[currentIndex];

    }
}
