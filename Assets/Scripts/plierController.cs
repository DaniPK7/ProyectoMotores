using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plierController : MonoBehaviour
{
    public GameObject plier, plierHUD, text;
    void Start()
    {
        plier.gameObject.SetActive(true);
        plierHUD.gameObject.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                text.SetActive(false);
                Destroy(plier);
                plierHUD.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
