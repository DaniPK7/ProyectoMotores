using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator playerAnim;
    private Movement playerMov;

    public float cSpeed;
    public
    //maxSpeed:6f       walkSpeed:1.5f

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMov = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(playerMov.playerSpeed / 6);

        /*float speed = playerMov.playerSpeed/6;
        if (speed < 0.05){ cSpeed = 0; }
        else if (speed<0.55) 
        {
            cSpeed = 0.5f;
        }
        else if (speed==1)
        {
            cSpeed =1;
        }
        playerAnim.SetFloat("currentSpeed", cSpeed);*/


        //axxx();
        //if (playerMov.maxSpeed == 6) { cSpeed = 2; }
        // if(playerMov.playerSpeed)
        //playerAnim.SetFloat("currentSpeed",MaplayerMov.playerSpeed / 6);
    }

    void axxx()
    {
        if (true)//averiguar como hacer las anims bien y fluidas
        {

        }
    }

    //currentSpeed
}
