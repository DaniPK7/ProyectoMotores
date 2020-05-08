using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatBeha : MonoBehaviour
{

    Animator animator;
    healthbar health;
    public bool gotHit = false;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<healthbar>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("GotHit", gotHit);
        gotHit = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("DeerSkullHand") && collider.enabled==true) 
        {
            if(health.currentHealth - 25f <= 0) { health.isDead = true; }
            health.takeDamage(25f);
            gotHit = true;
        }
    }

    
    public void hit() 
    {
        gotHit = false;
    }
}
