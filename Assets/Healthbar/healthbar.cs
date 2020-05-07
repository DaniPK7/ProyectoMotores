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
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        isDead = false;
        setHealthUI();
    }

    private void Update()
    {
        setHealthUI();
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
    }

    private void setHealthUI()
    {
        healthSlider.value = currentHealth;
        sliderImage.color = Color.Lerp(zeroHealth, fullHealt, currentHealth/startingHealth);
    }
}
