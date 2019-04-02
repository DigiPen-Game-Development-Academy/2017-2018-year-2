/*
Author; Luke Taranowski
Contributers: Kevin-sen Panasyuk
Last Edited: 3/22/2019
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
    public float firerate = 0;
    public int burstSize = 3;
    public float attackDamage;
    public float turnSpeedInDegrees;
    public int shotsLeft = 0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    bool lineOfSite = false;

    float timer = 0;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = firerate;
        shotsLeft = burstSize;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            //RaycastHit hit;
            //if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity);
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 100, Color.red, 100f, false);

            if (!lineOfSite) 
            {
                Vector3 difference = player.transform.position - transform.position;
                Vector3 newRotation = Vector3.RotateTowards(transform.right, difference, Mathf.Deg2Rad * turnSpeedInDegrees * Time.deltaTime, Vector3.Distance(transform.position, player.transform.position));
                transform.right = newRotation;

                if (timer <= 0)
                {
                    Sprite spriteToSpawn = sprite1;

                    int randomNumber = Random.Range(0, 6);
                    if (randomNumber < 2)
                        spriteToSpawn = sprite1;
                    if (randomNumber > 2 && randomNumber < 4)
                        spriteToSpawn = sprite2;
                    if (randomNumber > 4)
                        spriteToSpawn = sprite3;

                    Quaternion rotation = transform.rotation;
                    GameObject newProjectile = Instantiate(projectile, transform.position + transform.right, rotation *= Quaternion.Euler(0, 0, 90));

                    newProjectile.transform.localScale = new Vector3(2, 2, 2);
                    newProjectile.GetComponent<Hitbox>().isEnemy = true;
                    newProjectile.GetComponent<Hitbox>().damage = attackDamage;
                    newProjectile.GetComponent<TimedDeath>().deathTimer = projectileLifespan;

                    newProjectile.GetComponent<SpriteRenderer>().sprite = spriteToSpawn;
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
}
