/*
Author: Luke Taranowski
Contributors:NA
Last Edited: 1/29/2019s
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Stores the hitbox object we spawn
    public GameObject hitbox;

    // Public variable we can edit in inspector
    public float attackSpeed;
    // Private variable we can edit without effecting the public variable
    private float attackCooldown;

    Vector3 spawnPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        // Set the private variable to the public one
        attackCooldown = attackSpeed;
    }

    void Attack()
    {
        // Spawn hitbox in front of the player in the direction they are facing
        //Instantiate(hitbox, GetComponent<PlayerMovement>().direction + transform.position, transform.rotation);
        
    }
    // Update is called once per frame
    void Update()
    {
        // check if the attack cooldown has run out
        if (attackCooldown <= 0)
        {
            // If we recieve players input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Run the script with attack code
                Attack();

                // Reset the attackCooldown
                attackCooldown = attackSpeed;
            }
        }
        else // Reduce the attackCooldown
            attackCooldown -= Time.deltaTime;

    }
}
