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

    public GameObject  exitConfig, configButton ,  cancelExit;

    public Animator cameraAnim, configAnimator;

    public EventSystem eventSystem;

    private GameObject selected;

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

        cameraAnim.SetBool("OpenConfig", true);
        configAnimator.SetBool("OpenConfig", true);

        eventSystem.SetSelectedGameObject(exitConfig);
    }

    public void HideConfigMenu()
    {
        buttons.SetActive(true);

       // configMenu.SetActive(false);

        cameraAnim.SetBool("OpenConfig", false);
        configAnimator.SetBool("OpenConfig", false);

        eventSystem.SetSelectedGameObject(configButton);
        
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
