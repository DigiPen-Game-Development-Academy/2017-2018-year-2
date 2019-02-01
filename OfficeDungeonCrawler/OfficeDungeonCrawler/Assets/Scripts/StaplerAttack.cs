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
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackCooldown = attackSpeed;
    }

    // Update is called once per frame
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
