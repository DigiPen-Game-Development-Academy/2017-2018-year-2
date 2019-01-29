using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int healthMeter = 5;
    Text health;
        
	// Use this for initialization
	void Start ()
    {
        health = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //healthMeter = healthMeter - 1;
        health.text = "HEALTH:" + healthMeter;
	}
}
