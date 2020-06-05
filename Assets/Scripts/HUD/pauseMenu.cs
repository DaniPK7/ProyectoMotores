using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class pauseMenu : MonoBehaviour
{
    Movement playerSC;

    public GameObject menuPause, deathMenu, buttons, sureDialog, configMenu;
    public GameObject resumeButton, configExit, exitGameConfirmation, restartButton;

    //public GameObject buttons;

    public bool gamePaused, dead;

    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        playerSC = FindObjectOfType<Movement>();
        gamePaused = false;
        dead = false;
        Time.timeScale = 1f;

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

        if (!playerSC.playerAlive)
        {
            ShowDeathMenu();

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && playerSC.playerAlive)
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

    private void ShowDeathMenu()
    {
        if (!dead)
        {
            dead = true;
            deathMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restartButton);

            Time.timeScale = 0f;
            Cursor.visible = true;
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

    public void RestartLvl() 
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(currentScene.name);


    }
}
