﻿/*
Author: Justin V
Contributors: N/A
Date Last Edited: 2/1/2019
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*	public int directionVar = 1;
        public float runSpeed = 1.5f;
        public float dashSpeed = 25.0f;
        public float staminaCapacity = 30;
        public float staminaCapacitycap = 30;
        bool frameDelayer = false;
        int rollDirection = 0;
        private Rigidbody2D rb;
        public Vector2 direction = Vector2.down;*/

    public float walkSpeed = 1;
    public float dashSpeed = 5;
    public float stamina = 3;
    public float dashTime = 0.5f;
    float dashTimeRemaining = 0.0f;
    Vector2 dashDirection = Vector2.zero;
    double currentSpeed = 0.0;
    // Use this for initialization
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(Settings.KeyBinds.down))
        {
            direction.y -= 1;
        }
        if (Input.GetKey(Settings.KeyBinds.up))
        {
            direction.y += 1;
        }
        if (Input.GetKey(Settings.KeyBinds.right))
        {
            direction.x += 1;
        }
        if (Input.GetKey(Settings.KeyBinds.left))
        {
            direction.x += -1;
        }

        currentSpeed = walkSpeed;

        if (Input.GetKey(Settings.KeyBinds.dash) && stamina >= 25)
        {
            currentSpeed = dashSpeed;
            dashDirection = direction.normalized;
            dashTimeRemaining = dashTime;
            stamina = 0;
        }

        if (dashTimeRemaining >= 0)
            direction = dashDirection;













        /*Vector2 velocity = Vector2.zero;
        if (frameDelayer)
        {
            if (rollDirection == 1)
            {
                velocity.x = dashSpeed;
                direction.x = 1;
                staminaCapacity -= 1.0f;
            }
            if (rollDirection == 2)
            {
                velocity.x = -dashSpeed;
                direction.x = -1;
                staminaCapacity -= 1.0f;
            }
            if (rollDirection == 3)
            {
                velocity.y = dashSpeed;
                direction.y = 1;
                staminaCapacity -= 1.0f;
            }
            if (rollDirection == 4)
            {
                velocity.y = -dashSpeed;
                direction.y = -1;
                staminaCapacity -= 1.0f;
            }
        }
        //frameDelayer == false &&
        //this if stament halts the dash loop when stamina runs out
        if (staminaCapacity <= 0) frameDelayer = false;
        if (staminaCapacity <= 0) rollDirection = 0;
        //this if stament adds to the current stamina when it isnt in the delayer loop and has space to fill
        if (staminaCapacity < staminaCapacitycap) staminaCapacity += Time.deltaTime;
        //this if stament checks if the dash delay loop is active if so it doesn't do it 
        if (frameDelayer == false)
        {
            Debug.Log("E");
            if (Input.GetKey(Settings.KeyBinds.up))
            {
                velocity.y += runSpeed;
                direction.y = 1;
            }
            if (Input.GetKey(Settings.KeyBinds.down))
            {
                velocity.y += -runSpeed;
                direction.y = -1;
            }
            if (Input.GetKey(Settings.KeyBinds.left))
            {
                velocity.x += -runSpeed;
                direction.x = -1;
            }
            if (Input.GetKey(Settings.KeyBinds.right))
            {
                velocity.x += runSpeed;
                direction.x = 1;
            }
        }

        ///these 4 if statements check if the player can and wants to dash and roll direction specifies where
        if (Input.GetKey(Settings.KeyBinds.right) && Input.GetKey(Settings.KeyBinds.dash) && staminaCapacity >= staminaCapacitycap)
        {
            frameDelayer = true;
            rollDirection = 1;
        }
        if (Input.GetKey(Settings.KeyBinds.left) && Input.GetKey(Settings.KeyBinds.dash) && staminaCapacity >= staminaCapacitycap)
        {
            frameDelayer = true;
            rollDirection = 2;
        }
        if (c && Input.GetKey(Settings.KeyBinds.dash) && staminaCapacity >= staminaCapacitycap)
        {
            frameDelayer = true;
            rollDirection = 3;
        }
        if (Input.GetKey(Settings.KeyBinds.down) && Input.GetKey(Settings.KeyBinds.dash) && staminaCapacity >= staminaCapacitycap)
        {
            frameDelayer = true;
            rollDirection = 4;
        }
        rb.velocity = velocity;

    }*/
    }
}