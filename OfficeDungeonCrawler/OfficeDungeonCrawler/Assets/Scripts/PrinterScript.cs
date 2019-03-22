/*
Author; Luke Taranowski
Contributers;
Last Edited: 3/19/2019
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterScript : MonoBehaviour
{
    public GameObject projectile;
    GameObject player;

    public float projectileSpeed;
    public float projectileLifespan;
    public float detectionRange;
    public float firerate;
    public float attackDamage;
    public float turnSpeedInDegrees;

    float timer;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        projectile.GetComponent<Hitbox>().isEnemy = true;
        projectile.GetComponent<Hitbox>().damage = attackDamage;
        projectile.GetComponent<TimedDeath>().deathTimer = projectileLifespan;
        timer = firerate;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            Vector3 difference = player.transform.position - transform.position;
            Vector3 newRotation = Vector3.RotateTowards(transform.right, difference, Mathf.Deg2Rad * turnSpeedInDegrees * Time.deltaTime, Vector3.Distance(transform.position, player.transform.position));
            transform.right = newRotation;


            if (timer <= 0)
            {
                GameObject newProjectile = Instantiate(projectile, transform.position + transform.right, transform.rotation);
                newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;

                timer = firerate;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
