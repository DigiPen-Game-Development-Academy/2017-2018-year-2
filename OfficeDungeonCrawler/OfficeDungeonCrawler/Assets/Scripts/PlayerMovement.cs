/*
Author: Justin V
Contributors: N/A
Date Last Edited: 1/29/2019
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int directionVar = 1;
	public float runSpeed = 1.5f;
	public float dashSpeed = 5.0f;
	private Rigidbody rb;
    Vector3 direction = Vector3.down;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update ()
	{

        var Velocity = new Vector3();
		if(Input.GetKey(Settings.KeyBinds.up))
		{
            Velocity.y = runSpeed;
            direction.y = 1;
            //rb.addforce(0,1,0);
		}
        if(Input.GetKey(Settings.KeyBinds.down))
        {
            Velocity.y = -runSpeed;
            direction.y = -1;
        }
        if (Input.GetKey(Settings.KeyBinds.left)) 
        {
            Velocity.x = -runSpeed;
            direction.x = -1;
        }
        if (Input.GetKey(Settings.KeyBinds.right)) 
        {
            Velocity.x = runSpeed;
            direction.x = 1;
        }
        //start of the dash code
        if(Input.GetKey(Settings.KeyBinds.right) && Input.GetKey(Settings.KeyBinds.dash))
        {
            Velocity.x = dashSpeed;
            direction.x = 1;
        }
        if (Input.GetKey(Settings.KeyBinds.left) && Input.GetKey(Settings.KeyBinds.dash))
        {
            Velocity.x = -dashSpeed;
            direction.x = -1;
        }
        if (Input.GetKey(Settings.KeyBinds.up) && Input.GetKey(Settings.KeyBinds.dash))
        {
            Velocity.y = dashSpeed;
            direction.y = 1;
        }
        if (Input.GetKey(Settings.KeyBinds.down) && Input.GetKey(Settings.KeyBinds.dash))
        {
            Velocity.y = -dashSpeed;
            direction.y = -1;
        }


        rb.velocity = Velocity;

    }
}
