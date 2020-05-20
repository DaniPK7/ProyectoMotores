using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plierController : MonoBehaviour
{
    public GameObject plier;
    public GameObject plierHUD;
    void Start()
    {
        plier.gameObject.SetActive(true);
        plierHUD.gameObject.SetActive(false);
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
                Destroy(plier);
                plierHUD.gameObject.SetActive(true);
            }
        }
    }
}
