using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public GameObject title, buttons, playAgainBtn, exitBtn, homeBtn;
    void Start()
    {
        title.SetActive(true);
        buttons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(playAgainBtn);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Environment");
    }

    public void Home()
    {
        SceneManager.LoadScene("welcomeScreen");
    }
}
