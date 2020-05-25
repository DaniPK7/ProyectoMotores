using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class activateLightOnSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public EventSystem   eventSystem;

    public GameObject playLight, configLight, exitLight;

    private string selected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selected = eventSystem.currentSelectedGameObject.gameObject.name;

        if (selected == "Play") 
        {
            playLight.SetActive(true);
            configLight.SetActive(false);
            exitLight.SetActive(false);
        } 

        else if (selected == "ConfigBtn")
        {
            playLight.SetActive(false);
            configLight.SetActive(true);
            exitLight.SetActive(false);
        } 

        else if (selected == "Exit")
        {
            playLight.SetActive(false);
            configLight.SetActive(false);
            exitLight.SetActive(true);
        } 

        print("selected= " + selected);
    }
}
