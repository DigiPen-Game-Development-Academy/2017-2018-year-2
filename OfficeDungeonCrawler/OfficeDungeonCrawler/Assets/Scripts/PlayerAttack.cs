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
    public float attackAnimTime = 0.5f;
    float timeTillResetAnim = 0.0f;

    PlayerMovement playerMovement;

    Animator animator;

    new public GameObject camera;

    public float movePauseTime = 0.2f;

    Camera cameraComponent;

    SpriteRenderer spriteRenderer;

    //Vector2 spawnPos = new Vector2();
    // this catAttack checks if the player is allowed to attack currently only being used from the movement script
    public bool canAttack = true;

    void Start()
    {
        // Set the private variable to the public one
        attackCooldown = attackSpeed;
        hitbox.GetComponent<Hitbox>().isEnemy = false;
        hitbox.GetComponent<Hitbox>().damage = attackDamage;
        cameraComponent = camera.GetComponent<Camera>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Attack()
    {
        if (canAttack)
        {
            Vector3 position = cameraComponent.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            Vector3 direction = Vector3.Normalize(position - transform.position);

            // Spawn hitbox in front of the player in the direction they are facing
            Hitbox newHitbox = Instantiate(hitbox, transform.position + direction, transform.rotation).GetComponent<Hitbox>();

            newHitbox.damage = attackDamage;
            newHitbox.isEnemy = false;

            playerMovement.timeTillCanMove = movePauseTime;

            timeTillResetAnim = attackAnimTime;

            //Elena's Code (Probably Broken)

            if (direction.x <= -0.5)
            {
                animator.SetBool("MeleeSide", true);
                animator.SetBool("MeleeFront", false);
                animator.SetBool("MeleeBack", false);
                spriteRenderer.flipX = true;
            }
            else if (direction.x >= 0.5)
            {
                animator.SetBool("MeleeSide", true);
                animator.SetBool("MeleeFront", false);
                animator.SetBool("MeleeBack", false);
            }
            if (direction.y >= 0.5)
            {
                animator.SetBool("MeleeSide", false);
                animator.SetBool("MeleeFront", false);
                animator.SetBool("MeleeBack", true);
            }
            else if (direction.y <= -0.5)
            {
                animator.SetBool("MeleeFront", true);
                animator.SetBool("MeleeSide", false);
                animator.SetBool("MeleeBack", false);
            }
        }
    }

    void Update()
    {
        timeTillResetAnim -= Time.deltaTime;

        if (timeTillResetAnim <= 0.0f)
        {
            animator.SetBool("MeleeSide", false);
            animator.SetBool("MeleeFront", false);
            animator.SetBool("MeleeBack", false);
        }

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
