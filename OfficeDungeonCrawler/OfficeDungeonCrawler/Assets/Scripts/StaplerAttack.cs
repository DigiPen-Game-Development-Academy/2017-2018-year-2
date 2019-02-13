/*
Author: Luke T
Contributors: N/A
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaplerAttack : MonoBehaviour
{
    GameObject player;
    public GameObject hitbox;

    public float attackDistance = 1;
    public float attackSpeed = 1;
    float attackCooldown;
	public float fastAttackChargeTime = 0.5f;
	
	public float longAttackChargeTime = 1.0f;
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackCooldown = attackSpeed;
    }
	
    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        var spawnPos = new Vector3();
        if(distance <= attackDistance && attackCooldown <= 0)
        {
            spawnPos = player.transform.position;
            Instantiate(hitbox, spawnPos, transform.rotation);
            attackCooldown = attackSpeed;
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
}
