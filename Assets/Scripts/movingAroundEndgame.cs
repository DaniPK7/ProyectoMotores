using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movingAroundEndgame : MonoBehaviour
{
    public GameObject playAgainBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movingAround()
    {
        EventSystem.current.SetSelectedGameObject(playAgainBtn);
    }
}
