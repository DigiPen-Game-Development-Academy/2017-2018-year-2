/*
Author: Luke T
Contributors: Myles Busig
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaplerAttack : MonoBehaviour
{
	public GameObject hitbox;

	public float attackDistance = 1;

	[HideInInspector]
	public float fastAttackChargeTime = 0.5f;
	[HideInInspector]
	public float fastAttackCooldown = 0.5f;
	[HideInInspector]
	public float fastAttackDamage = 0.5f;
	[HideInInspector]
	float timeTillFastCharge = 0.0f;
	[HideInInspector]
	float timeTillFastAttack = 0.0f;

	[HideInInspector]
	public float longAttackChargeTime = 1.0f;
	[HideInInspector]
	public float longAttackCooldown = 1.5f;
	[HideInInspector]
	public float longAttackDamage = 2.0f;
	[HideInInspector]
	float timeTillLongCharge = 0.0f;
	[HideInInspector]
	float timeTillLongAttack = 0.0f;

	public float attackCooldown = 1.0f;
	public float attackChargeTime = 0.5f;
	public float attackDamage = 1.0f;
	float timeTillAttack;

	Vector3 attackPosition = Vector3.zero;

	EnemyMovement enemyMovement;
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemyMovement = GetComponent<EnemyMovement>();

		timeTillFastAttack = fastAttackCooldown;
		timeTillLongAttack = longAttackCooldown;

		timeTillAttack = attackCooldown;
	}

	void Update()
	{
		if (player == null)
			return;

		float distance = Vector3.Distance(transform.position, player.transform.position);

		timeTillAttack -= Time.deltaTime;

		if (distance <= attackDistance)
		{
			if (timeTillAttack <= 0.0f)
			{
				enemyMovement.canMove = false;
			}
			else
			{
				attackPosition = player.transform.position;

				enemyMovement.canMove = true;
			}

			if (timeTillAttack <= -attackChargeTime)
			{
				GameObject newHitbox = Instantiate(hitbox, Vector3.Lerp(attackPosition, player.transform.position, 0.5f), Quaternion.Euler(Vector3.zero));

				Hitbox hitboxComponent = newHitbox.GetComponent<Hitbox>();
				hitboxComponent.isEnemy = true;
				hitboxComponent.damage = attackDamage;

				timeTillAttack = attackCooldown;
			}
		}

		//float distance = Vector3.Distance(transform.position, player.transform.position);

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
		//		GameObject newHitbox = Instantiate(hitbox, attackPosition, Quaternion.Euler(Vector3.zero));

		//		timeTillLongCharge = longAttackCooldown;
		//		timeTillLongAttack = longAttackChargeTime;
		//		timeTillFastCharge = fastAttackCooldown;
		//		timeTillFastAttack = fastAttackChargeTime;

		//		enemyMovement.canMove = true;
		//	}
		//	else if (timeTillFastAttack <= 0.0f)
		//	{
		//		GameObject newHitbox = Instantiate(hitbox, attackPosition, Quaternion.Euler(Vector3.zero));

		//		timeTillFastCharge = fastAttackCooldown;
		//		timeTillFastAttack = fastAttackChargeTime;

		//		enemyMovement.canMove = true;
		//	}
		//}
		//else
		//	enemyMovement.canMove = true;
	}
}
