using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batteryManagement : MonoBehaviour
{
    [SerializeField]
    List<Texture> batteryImages;

    int currentIndex;

    private RawImage currentImage;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<RawImage>();
      

        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            currentIndex += 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (--currentIndex < 0)
            {
                currentIndex = currentIndex - 1;
            }
        }

        //currentImage = batteryImages[currentIndex];
        currentImage.texture =  batteryImages[currentIndex];

    }
}
