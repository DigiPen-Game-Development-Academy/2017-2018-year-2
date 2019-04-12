/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterBozz : MonoBehaviour {
    public bool moving = false;
    public bool shooting = false;
    public float switchSpeed = 1;
    public float CurrentHealth = 0;
    //beggining of boss phase stats
    //duration is how long it shoots for at each phase
    public float phase1ShootDuration = 0;
    public float phase2ShootDuration = 0;
    public float phase3ShootDuration = 0;
    public float phase4ShootDuration = 0;

    //shot cooldown controls how long each burst lasts 
    public float phase1ShootCooldown = 0;
    public float phase2ShootCooldown = 0;
    public float phase3ShootCooldown = 0;
    public float phase4ShootCooldown = 0;

    //trigger is when he changes phases when a certain health it reached
    public float phase1Healthtrigger = 90;
    public float phase2HealthTrigger = 75;
    public float phase3HealthTrigger = 50;
    public float phase4HealthTrigger = 30;

    //move means hoow fast he can move at each stage
    public float phase1Move = 0;
    public float phase2Move = 0;
    public float phase3Move = 0;
    public float phase4Move = 0;

    //intensity just means how strong the fire rate is going to be.
    public float phase1ShootIntensity = 0;
    public float phase2ShootIntensity = 0;
    public float phase3ShootIntensity = 0;
    public float phase4ShootIntensity = 0;

    //how much the boss does when hitting the player at each phase
    public float phase1Melee = 0;
    public float phase2Melee = 0;
    public float phase3Melee = 0;
    public float phase4Melee = 0;
    
    //this controls when the boss can move towards the player till its in proper range
    public float optimalShootingDistance;
    public float moveTime = 0;
    public float shootTime = 0;

    //end of boss stats
    [HideInInspector]
    public float timer = 0;
    [HideInInspector]
    public float Health;
    public GameObject Player = null;
    
	// Use this for initializon
	void Start () {
       Health = gameObject.GetComponent<Health>().maxHealth;
        Player = GameObject.Find("Player");
        gameObject.GetComponent<Health>().CurrentHealth = Health;
        shootTime = -shootTime;
       //if(gameObject.GetComponent<>)
    }
	
	// Update is called once per frame
	void Update () {
        CurrentHealth = gameObject.GetComponent<Health>().currentHealth;

        if(timer >= moveTime)
        {
            if (vector3.Distance(Player.transform.position, transform.position) >= optimalShootingDistance)
            {
                gameObject.GetCompoenent<EnemyMovement>().bossConditions = true;
            } 
        }
        
        if (CurrentHealth <= phase1Healthtrigger && CurrentHealth >= phase2HealthTrigger)
        {
            gameObject.GetComponent<PrinterScript>().fireRate = phase1ShootIntensity;
            gameObject.GetComponent<PrinterScript>().burstDuration = phase1ShootDuration;
            gameObject.GetComponent<PrinterScript>().burstTimeCoolDown = phase1ShootCooldown;
            gameObject.GetComponent<EnemyMovement>().speed = phase1Move;
            gameObject.GetComponent<StaplerAttack>().attackDamage = phase1Melee;
            if (CurrentHealth <= phase2HealthTrigger && CurrentHealth >= phase3HealthTrigger)
            {
                gameObject.GetComponent<PrinterScript>().fireRate = phase2ShootIntensity;
                gameObject.GetComponent<PrinterScript>().burstDuration = phase2ShootDuration;
                gameObject.GetComponent<PrinterScript>().burstTimeCoolDown = phase2ShootCooldown;
                gameObject.GetComponent<EnemyMovement>().speed = phase2Move;
                gameObject.GetComponent<StaplerAttack>().attackDamage = phase2Melee;
                if (CurrentHealth <= phase3HealthTrigger && CurrentHealth >= phase4HealthTrigger)
                {
                    gameObject.GetComponent<PrinterScript>().fireRate = phase3ShootIntensity;
                    gameObject.GetComponent<PrinterScript>().burstDuration = phase3ShootDuration;
                    gameObject.GetComponent<PrinterScript>().burstTimeCoolDown = phase3ShootCooldown;
                    gameObject.GetComponent<EnemyMovement>().speed = phase3Move;
                    gameObject.GetComponent<StaplerAttack>().attackDamage = phase3Melee;
                    if (CurrentHealth <= phase4HealthTrigger)
                    {
                        gameObject.GetComponent<PrinterScript>().fireRate = phase4ShootIntensity;
                        gameObject.GetComponent<PrinterScript>().burstDuration = phase4ShootDuration;
                        gameObject.GetComponent<PrinterScript>().burstTimeCoolDown = phase4ShootCooldown;
                        gameObject.GetComponent<EnemyMovement>().speed = phase4Move;
                        gameObject.GetComponent<StaplerAttack>().attackDamage = phase4Melee;
                    }
                }
            }
        }
        if (timer <= 0)
        {
            gameobject.GetComponent<PrinterScript>().bossConditions = true;
            gameobject.GetComponent<EnemyMovement>().bossConditions = false;
        }
        if(timer >= 0)
        {
            gameobject.GetComponent<PrinterScript>().bossConditions = false;
            gameobject.GetComponent<EnemyMovement>().bossConditions = true;
        }
        if (timer >= movetime) timer = shootTime;
    timer += Time.deltaTime * switchSpeed;
	}
}
*/