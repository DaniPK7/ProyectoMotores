using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    public float startingHealth = 100f;
    public Slider healthSlider;
    public Image sliderImage;
    public Color fullHealt = Color.green;
    public Color zeroHealth = Color.red;

    public float currentHealth;
    public bool isDead;

    Movement movementSC;
    public GameObject player;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        isDead = false;
        setHealthUI();
        playerAnimator = player.GetComponent<Animator>();

        movementSC = FindObjectOfType<Movement>();
    }

    private void Update()
    {
        setHealthUI();
        if (currentHealth <= 0)
            death();
    }

    public void takeDamage(float damage)
    {
        print("holi");
        currentHealth -= damage;
        setHealthUI();
        if (currentHealth <= 0 && !isDead)
            death();
    }

    private void death()
    {
        isDead = true;
        movementSC.playerAlive = false;
        

        playerAnimator.SetTrigger("DeadTrigger");
    }

    private void setHealthUI()
    {
        healthSlider.value = currentHealth;
        sliderImage.color = Color.Lerp(zeroHealth, fullHealt, currentHealth/startingHealth);
    }
}
