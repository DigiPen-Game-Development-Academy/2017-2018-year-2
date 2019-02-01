using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public int startingHealth = 10;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    bool isDead;
    bool damaged;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponentInChildren<PlayerAttack>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //if player takes damage
        if (damaged)
        {
            //player health depletes by 1
            //startingHealth = startingHealth - 1;
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death ()
    {
        isDead = true;

        anim.SetTrigger("Dead");

        playerMovement.enabled = false;
        playerAttack.enabled = false;
    }
}
