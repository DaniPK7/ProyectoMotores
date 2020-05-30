using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;


public class welcomeScreen : MonoBehaviour
{

    public GameObject buttons, sureDialog, configMenu;

    /*public Texture2D mouse;
    Texture2D mouseText;*/

    public GameObject  exitConfig, configButton , exitButton,  cancelExit;

    public Animator cameraAnim, configAnimator;

    public EventSystem eventSystem;

    private GameObject selected;

    

    //
    private bool infoBool;
    public TextMeshProUGUI infoText;
    private string infoString;

    // Start is called before the first frame update
    void Start()
    {
       /* mouseText = (Texture2D)Resources.Load("mouse");
        Cursor.SetCursor(mouseText, Vector2.zero, CursorMode.Auto);
        //Cursor.visible = false;*/

        infoBool = false;
        infoString = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.SetCursor(mouseText, Vector2.zero,CursorMode.Auto);
        //mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        showControls();
    }

    public void StartGame() 
    {
        cameraAnim.SetTrigger("Play");

        print(cameraAnim.GetCurrentAnimatorStateInfo(1));
    }
    public void ShowSureMenu()
    {
        buttons.SetActive(false);

        cameraAnim.SetBool("ExitConfig", true);

        sureDialog.SetActive(true);

        eventSystem.SetSelectedGameObject(cancelExit);

    }

    public void HideSureMenu()
    {
        buttons.SetActive(true);

        cameraAnim.SetBool("ExitConfig", false);


        sureDialog.SetActive(false);

        eventSystem.SetSelectedGameObject(exitButton);


    }

    public void ShowConfigMenu()
    {
        buttons.SetActive(false);

        configMenu.SetActive(true);

        cameraAnim.SetBool("OpenConfig", true);
        infoBool = true;
        configAnimator.SetBool("OpenConfig", infoBool);

        eventSystem.SetSelectedGameObject(exitConfig);
    }

    public void HideConfigMenu()
    {
        buttons.SetActive(true);

       // configMenu.SetActive(false);

        cameraAnim.SetBool("OpenConfig", false);
        infoBool = false;

        configAnimator.SetBool("OpenConfig", infoBool);

        eventSystem.SetSelectedGameObject(configButton);
        
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    private void showControls() 
    {
        if (infoBool) 
        {
            if (Input.GetKey(KeyCode.W))                { infoString = "move character forward"; }
            else if (Input.GetKey(KeyCode.A))           { infoString = "move character to the left"; }
            else if (Input.GetKey(KeyCode.S))           { infoString = "move character backwards"; }
            else if (Input.GetKey(KeyCode.D))           { infoString = "move character to the right"; }
            else if (Input.GetKey(KeyCode.R))           { infoString = "pick objects"; }
            else if (Input.GetKey(KeyCode.LeftShift))   { infoString = "sprint"; }
            else if (Input.GetKey(KeyCode.Space))       { infoString = "jump"; }
            else if (Input.GetKey(KeyCode.Escape))      { infoString = "pause menu"; }
            else if (Input.GetKey(KeyCode.E))           { infoString = "turn on / off lantern"; }
            else                                        { infoString = "press the key to see functionality"; }


            infoText.text = infoString;

        }
    }

}
