using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterBozz : MonoBehaviour {
    public bool moving = false;
    public bool shooting = false;
    public float switchSpeed = 1;
    public float CurrentHealth = 0;

    [HideInInspector]
    public float timer = 0;
    [HideInInspector]
    public float Health;
    
	// Use this for initializon
	void Start () {
       Health = gameObject.GetComponent<Health>().maxHealth;
       
    }
	
	// Update is called once per frame
	void Update () {
        CurrentHealth = gameObject.GetComponent<Health>().currentHealth;

        if (CurrentHealth >= 0.90 * Health && CurrentHealth <= 0.75 * Health)
        {




        }
        if(CurrentHealth <= 0.25 * Health && CurrentHealth >= 0.50 * Health)
        {

        }
        if (CurrentHealth <= 0.25 * Health && CurrentHealth >= 0.50 * Health)
        {

        }
        if (CurrentHealth <= 0.25 * Health && CurrentHealth >= 0.50 * Health)
        {

        }
            timer += Time.deltaTime * switchSpeed;
	}
}
