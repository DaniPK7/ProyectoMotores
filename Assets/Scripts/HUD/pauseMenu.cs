using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class pauseMenu : MonoBehaviour
{
    Movement playerSC;

    public GameObject menuPause, buttons, sureDialog, configMenu;
    public GameObject resumeButton, configExit, exitGameConfirmation;

    //public GameObject buttons;

    public bool gamePaused;

    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        playerSC = FindObjectOfType<Movement>();
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused)
        {
            Cursor.visible = gamePaused;
        }
        else 
        {
            Cursor.visible = gamePaused;

        }

        currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Escape) && playerSC.playerAlive)
        {
            if (gamePaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        //Cursor.visible = true;

        menuPause.SetActive(true);
        buttons.SetActive(true);

        sureDialog.SetActive(false);
        configMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(resumeButton);

        Time.timeScale = 0f;
        gamePaused = true;        

        /*EventSystem.current.SetSelectedGameObject(ResumeButton);
        ResumeButton = EventSystem.current.currentSelectedGameObject;*/

    }
    public void Resume()
    {

        //Cursor.visible = false;

        EventSystem.current.SetSelectedGameObject(null);

        menuPause.SetActive(false);
        //ControlMenuUI.SetActive(false);


        Time.timeScale = 1f;
        gamePaused = false;

    }
    public void ShowSureMenu() 
    {
        buttons.SetActive(false);

        EventSystem.current.SetSelectedGameObject(exitGameConfirmation);

        sureDialog.SetActive(true);
    }

    public void HideSureMenu() 
    {
        buttons.SetActive(true);

        sureDialog.SetActive(false);

        EventSystem.current.SetSelectedGameObject(resumeButton);


    }

    public void ShowConfigMenu()
    {
        buttons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(configExit);


        configMenu.SetActive(true);
    } 

    public void HideConfigMenu()
    {
        buttons.SetActive(true);

        configMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(resumeButton);

    }

    public void ExitGame()
    {
       Application.Quit();
    }
}
