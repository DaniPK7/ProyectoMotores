using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    healthbar health;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<healthbar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            health.takeDamage(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
