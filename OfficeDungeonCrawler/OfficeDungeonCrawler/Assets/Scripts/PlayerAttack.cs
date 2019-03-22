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
    // Public variable for how much damage the player does
    public float attackDamage = 1.0f;

	new public GameObject camera;

	Camera cameraComponent;

    Vector2 spawnPos = new Vector2();
	
    void Start()
    {
        // Set the private variable to the public one
        attackCooldown = attackSpeed;
        hitbox.GetComponent<Hitbox>().isEnemy = false;
        hitbox.GetComponent<Hitbox>().damage = attackDamage;
		cameraComponent = camera.GetComponent<Camera>();
    }

    void Attack()
    {
		Vector3 position = cameraComponent.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;

		Vector3 direction = Vector3.Normalize(position - transform.position);

		Debug.Log("Dir: " + direction);

		// Spawn hitbox in front of the player in the direction they are facing
		Hitbox newHitbox = Instantiate(hitbox, transform.position + direction, transform.rotation).GetComponent<Hitbox>();

		newHitbox.damage = attackDamage;
		newHitbox.isEnemy = false;
	}

    void Update()
    {
        // check if the attack cooldown has run out
        if (attackCooldown <= 0)
        {
            // If we recieve players input
            if (Input.GetMouseButtonDown(0))
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
