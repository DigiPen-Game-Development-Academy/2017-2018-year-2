/*
Author; Luke Taranowski luke wuz here and he i mean I messed it up;
Contributers: Kevin-sen Panasyuk
justin Van Der Sluys
Last Edited: 4/4/2019
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterScript : MonoBehaviour
{
	public GameObject projectile;
	public GameObject player;
	public bool bossConditions = true;
	public float projectileSpeed;
	public float projectileLifespan;
    public float detectionRange;
	public int burstSize = 3;
	public float attackDamage;
	public float turnSpeedInDegrees;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	bool lineOfSight = false;
	public float fireRate = 5;
	public LayerMask m_layerMask;
	public float burstDuration = 0;
	[HideInInspector]
	public bool allowedFire = false;
	[HideInInspector]
	public float timer = 0;
	[HideInInspector]
	public float burstTimer = 0;
	public float burstTimeCoolDown = 0;
	public Sprite ShootingPrinterFront;
	public Sprite notShootingPrinter;
	public float signalTime = 0.5f;
	public AudioClip shootSound;
	
	void Start()
	{
        if(!player)
        {
		    player = GameObject.Find("Player");
        }
		timer = firerate;
		shotsLeft = burstSize;
		fireRate = Time.deltaTime * fireRate;
		if (burstTimeCoolDown > 0)
			burstTimeCoolDown = -burstTimeCoolDown;
	}

	void Update()
	{
        if (player == null) return;
		if (Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
		{
			//OLD CODE
			//Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, Mathf.Infinity);
			//Debug.DrawRay(transform.position, dir * 10, Color.red, 100f, false);
			//-----------------//
			//CHRIS ONORATI CODE
			Vector3 dir = player.transform.position - transform.position + (Vector3)player.GetComponent<CircleCollider2D>().offset;
			dir.Normalize();

			//just a different method to make a raycast - I recommend avoiding out.
			RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100.0f, m_layerMask);

			//END CHRIS CODE
			//-----------------//

			burstTimer += Time.deltaTime;

			//Debug.Log(hit.collider.tag);
			if (hit.collider.tag.Equals("Player"))
			{
				lineOfSight = true;
			}
			else
			{
				lineOfSight = false;
			}
			if (lineOfSight)
			{
				Vector3 difference = player.transform.position - transform.position;
				Vector3 newRotation = Vector3.RotateTowards(transform.right, difference, Mathf.Deg2Rad * turnSpeedInDegrees * Time.deltaTime, Vector3.Distance(transform.position, player.transform.position));
				transform.right = newRotation;
				if (bossConditions)
				{
					if (timer <= 0 && allowedFire == true)
					{
						Debug.Log("Shoot Player");
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

						newProjectile.GetComponent<Hitbox>().isEnemy = true;
						newProjectile.GetComponent<Hitbox>().damage = attackDamage;
						newProjectile.GetComponent<TimedDeath>().deathTimer = projectileLifespan;

						newProjectile.GetComponent<SpriteRenderer>().sprite = spriteToSpawn;
						newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;

						GetComponent<AudioSource>().PlayOneShot(shootSound);
						
						timer = firerate;
					}
					else
					{
						timer -= fireRate;
					}
				}

				if (burstTimer >= 0)
                { 
					allowedFire = true;
				}
				if (burstTimer >= -signalTime)
				{
					GetComponent<SpriteRenderer>().sprite = ShootingPrinterFront;

					SpriteRenderer csr = transform.Find("Glow").GetComponent<SpriteRenderer>();
					csr.color = new Color(1.0f, 0.0f, 0.0f, csr.color.a);
				}
				if (burstTimer >= burstDuration && allowedFire == true)
				{
					GetComponent<SpriteRenderer>().sprite = notShootingPrinter;
					allowedFire = false;
					burstTimer = burstTimeCoolDown;

					SpriteRenderer csr = transform.Find("Glow").GetComponent<SpriteRenderer>();
					csr.color = new Color(0.0f, 1.0f, 0.0f, csr.color.a);
				}

			}
		}
	}
}

