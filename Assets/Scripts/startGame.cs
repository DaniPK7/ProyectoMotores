using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject load;
    Scene game;
    private void Start()
    {
         game = SceneManager.GetSceneByName("Environment");
    }

    public void StarThetGame()
    {

        load.SetActive(true);
        SceneManager.LoadSceneAsync("Environment");

    }
    private void Update()
    {
        
        if (game.isLoaded) 
        {
            SceneManager.LoadScene("Environment");
        }


    }
}
