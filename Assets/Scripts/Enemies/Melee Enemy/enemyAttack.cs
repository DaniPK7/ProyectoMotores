using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    healthbar health;
    public BoxCollider hand;

    enemyPatrol enemyPatrolSC;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<healthbar>();
        enemyPatrolSC = FindObjectOfType<enemyPatrol>();
        hand.enabled = false;
    }
      

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player"))
            health.takeDamage(5);*/
    }

    public void punchON() 
    {
        hand.enabled = true;
    } 
    
    public void punchOFF() 
    {
        hand.enabled = false;
    }
}
