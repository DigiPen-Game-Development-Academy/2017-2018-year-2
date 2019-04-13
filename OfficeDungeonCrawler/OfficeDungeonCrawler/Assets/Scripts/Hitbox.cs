/*
Author: Luke Taranowski
Contributors: N/A
Date Last Modified: 3/8/2019
*/

using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool isEnemy;
    public float damage;
    public float knockbackMultiplier;
    public float knockbackDuration;
    public GameObject enemyDamagedParticleEffect;
	void Start ()
    {

	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Breakable")
		{
			if (other.GetComponent<Breakable>().breakLevel >= other.GetComponent<Breakable>().sprites.Count - 1 && !other.GetComponent<Breakable>().canFullDestroy)
			{
				Destroy(gameObject);
				return;
			}

			++other.GetComponent<Breakable>().breakLevel;

			Vector3 spawnPosition = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 10);
			// Spawn the particle effect
			Instantiate(enemyDamagedParticleEffect, spawnPosition, other.gameObject.transform.rotation);

			Destroy(gameObject);
		}

        // Check if the object we collided with is a wall and we are the enemy
        if (other.tag == "Tileset" && isEnemy)
        {
            Destroy(gameObject);
        }
        // Check if the object we collided with is the player and we are the enemy
        if (other.tag == "Player" && isEnemy)
        {
            // Subtract damage from the other objects health
            other.gameObject.GetComponent<Health>().Damage(damage);
            other.gameObject.GetComponent<PlayerMovement>().timeTillCanMove = other.gameObject.GetComponent<PlayerMovement>().pauseOnHurt;
            Destroy(gameObject);

        }
        else if (other.tag == "Enemy" && !isEnemy) // Check if the object we collided with is the enemy and we are the player
        {
            // Subtract damage from the other objects health
            if(other.gameObject.GetComponent<Health>())
                other.gameObject.GetComponent<Health>().Damage(damage);

            if (other.gameObject.GetComponent<EnemyMovement>() != null)
            {
                Debug.Log("Oof");
                other.gameObject.GetComponent<EnemyMovement>().canMoveKnockback = false;
                other.gameObject.GetComponent<EnemyMovement>().canMoveAfterKnockback = knockbackDuration;

                // calculate the angle of attack
                Vector2 knockbackDirection = GameObject.FindGameObjectWithTag("Player").transform.position - other.gameObject.transform.position;

                // Add knockback effect to the enemy
                other.gameObject.GetComponent<Rigidbody2D>().velocity = -knockbackDirection.normalized * knockbackMultiplier;

            }

            Vector3 spawnPosition = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 10);
            // Spawn the particle effect
            Instantiate(enemyDamagedParticleEffect, spawnPosition, other.gameObject.transform.rotation);
        }
        else
        {
            return;
        }
    }
}
