/*
Author: Luke T
Contributors: Myles Busig, Kevin-sen Panasyuk, Elena S
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaplerAttack : MonoBehaviour
{
	public GameObject hitbox;

	public float attackDistance = 1;
    public bool bossvariable = true;
	public float attackCooldown = 1.0f;
	public float attackChargeTime = 0.5f;
	public float attackDamage = 1.0f;
	float timeTillAttack;

	Vector2 attackPosition = Vector2.zero;

    EnemyMovement enemyMovement;
	GameObject player;
    //PlayerAttack playerAttack= null;

    void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemyMovement = GetComponent<EnemyMovement>();

		timeTillAttack = attackCooldown;
	}

	void Update()
	{
        if (bossvariable)
        {

            if (player == null)
                return;

            float distance = Vector2.Distance(transform.position, player.transform.position);

            timeTillAttack -= Time.deltaTime;

            if (distance <= attackDistance)
            {
                Animator animator = GetComponent<Animator>();


                if (timeTillAttack <= 0.0f)
                {
                    enemyMovement.canMove = false;
                    animator.SetBool("AttackSide", false);
                    animator.SetBool("AttackFront", false);
                    animator.SetBool("AttackBack", false);
                    animator.SetBool("Idle", true);
                    animator.SetBool("WalkRight", false);
                    animator.SetBool("WalkBack", false);
                    animator.SetBool("WalkFront", false);
                }
                else
                {
                    attackPosition = player.transform.position;

                    enemyMovement.canMove = true;
                    animator.SetBool("AttackSide", true);
                    animator.SetBool("AttackFront", false);
                    animator.SetBool("AttackBack", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("WalkRight", false);
                    animator.SetBool("WalkBack", false);
                    animator.SetBool("WalkFront", false);
                }

                if (timeTillAttack <= -attackChargeTime)
                {
                    GameObject newHitbox = Instantiate(hitbox, Vector2.Lerp(attackPosition, player.transform.position, 0.5f), Quaternion.Euler(Vector2.zero));

                    Hitbox hitboxComponent = newHitbox.GetComponent<Hitbox>();
                    hitboxComponent.isEnemy = true;
                    hitboxComponent.damage = attackDamage;

                    timeTillAttack = attackCooldown;
                }
            }
            else
            {
                enemyMovement.canMove = true;

                timeTillAttack = attackChargeTime;
            }

            //if (playerAttack == true)
            //{
            //    timeTillAttack = attackCooldown;
            //}


            //float distance = Vector2.Distance(transform.position, player.transform.position);

            //Debug.Log("Attack pos: " + attackPosition);

            //Debug.Log("Tims, FC: " + timeTillFastCharge + ", FA: " + timeTillFastAttack + ", LC: " + timeTillLongCharge + ", LA: " + timeTillLongAttack);

            //if (distance <= attackDistance)
            //{
            //	timeTillLongCharge -= Time.deltaTime;
            //	timeTillFastCharge -= Time.deltaTime;

            //	if (timeTillLongCharge <= 0.0f)
            //	{
            //		timeTillLongAttack -= Time.deltaTime;

            //		enemyMovement.canMove = false;
            //	}
            //	else if (timeTillFastCharge <= 0.0f)
            //	{
            //		timeTillFastAttack -= Time.deltaTime;

            //		enemyMovement.canMove = false;
            //	}
            //	else
            //		attackPosition = player.transform.position;

            //	if (timeTillLongAttack <= 0.0f)
            //	{
            //		GameObject newHitbox = Instantiate(hitbox, attackPosition, Quaternion.Euler(Vector2.zero));

            //		timeTillLongCharge = longAttackCooldown;
            //		timeTillLongAttack = longAttackChargeTime;
            //		timeTillFastCharge = fastAttackCooldown;
            //		timeTillFastAttack = fastAttackChargeTime;

            //		enemyMovement.canMove = true;
            //	}
            //	else if (timeTillFastAttack <= 0.0f)
            //	{
            //		GameObject newHitbox = Instantiate(hitbox, attackPosition, Quaternion.Euler(Vector2.zero));

            //		timeTillFastCharge = fastAttackCooldown;
            //		timeTillFastAttack = fastAttackChargeTime;

            //		enemyMovement.canMove = true;
            //	}
            //}
            //else
            //	enemyMovement.canMove = true;
        }
    }
}
