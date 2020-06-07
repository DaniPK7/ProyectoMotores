using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public GameObject title, buttons, playAgainBtn, exitBtn, homeBtn;
    private float timer1, timer2, timer3;
    void Start()
    {
        title.SetActive(false);
        buttons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playAgainBtn);
        Cursor.visible = true;
        timer1 = 10;
        timer2 = 20;
        timer3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 <= timer3 && timer3 < 50)
        {
            title.SetActive(true);
        }

        if (timer2 <= timer3 && timer3 < 50)
        {
            buttons.SetActive(true);
        }
        if (timer3 < 50)
        {
            timer3++;
        }
        print(timer3);
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
