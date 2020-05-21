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

    public GameObject menuPause, buttons, sureDialog;

    //public GameObject buttons;

    bool gamePaused;

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
        currentScene= SceneManager.GetActiveScene();

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
        menuPause.SetActive(true);


        Time.timeScale = 0f;
        gamePaused = true;        

        /*EventSystem.current.SetSelectedGameObject(ResumeButton);
        ResumeButton = EventSystem.current.currentSelectedGameObject;*/

    }
    public void Resume()
    {

        EventSystem.current.SetSelectedGameObject(null);

        menuPause.SetActive(false);
        //ControlMenuUI.SetActive(false);


        Time.timeScale = 1f;
        gamePaused = false;

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

    public void ExitGame()
    {
       Application.Quit();
    }
}
