using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject textObject, openDoorSFX;
    bool allTaken;
    itemManage itemManage;
    //Scene postGame;
    public Animator doorAnim;
    public Light bunkerLight;

    Color lightColor;
    // Start is called before the first frame update
    void Start()
    {

        //postGame = SceneManager.GetSceneByName("PostGame");
        itemManage = FindObjectOfType<itemManage>();
        lightColor = Color.green;
        textObject.SetActive(false);
        openDoorSFX.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        allTaken = itemManage.allitemsTaken;

        //if (postGame.isLoaded) { SceneManager.LoadScene("PostGame");       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!allTaken)
            {
                //text.SetText("you need to find all the keys to open the door");
                textObject.SetActive(true);

            }
            else
            {
                textObject.SetActive(false);
                bunkerLight.color = lightColor;
                openDoorSFX.SetActive(true);
                doorAnim.SetTrigger("OpenTheDoor");


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            textObject.SetActive(false);


        }
    }

    public void endTheGame()
    {

    }
}
