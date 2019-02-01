using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int healthMeter = 10;
    Text health;

    bool isDead;
    bool damaged;
        
	// Use this for initialization
	void Start ()
    {
        health = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //healthMeter = healthMeter - 1;
        health.text = "HEALTH: " + healthMeter;

        //if player takes damage
        if (damaged)
        {
            //player health depletes by 1
            healthMeter = healthMeter - 1;
        }
        // if the player health depleted to 0 or under
        if(healthMeter <= 0)
        {
            // player is dead
            isDead = true;
        }
        else
        {
            isDead = false;
        }
	}
}
