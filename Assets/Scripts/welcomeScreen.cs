using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;



public class welcomeScreen : MonoBehaviour
{

    public GameObject  buttons, sureDialog, configMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Environment");
    }
    public void ShowSureMenu()
    {
        buttons.SetActive(false);

        sureDialog.SetActive(true);
    }

    public void HideSureMenu()
    {
        buttons.SetActive(true);

        sureDialog.SetActive(false);

    }

    public void ShowConfigMenu()
    {
        buttons.SetActive(false);

        configMenu.SetActive(true);
    }

    public void HideConfigMenu()
    {
        buttons.SetActive(true);

        configMenu.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
