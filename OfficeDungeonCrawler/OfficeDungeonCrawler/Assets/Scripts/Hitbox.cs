/*
Author: Luke Taranowski
Contributors: N/A
Date Last Modified: 2/15/2019
*/

using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool isEnemy;
    public float damage;
    public float knockbackMultiplier;
    public float knockbackDuration;
	void Start ()
    {

	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("HIT OBJ: " + other.gameObject);

        // Check if the object we collided with is the player and we are the enemy
        if (other.tag == "Player" && isEnemy)
        {
            // Subtract damage from the other objects health
            other.gameObject.GetComponent<Health>().Damage(damage);

        }
        else if (other.tag == "Enemy" && !isEnemy) // Check if the object we collided with is the enemy and we are the player
        {
            // Subtract damage from the other objects health
            other.gameObject.GetComponent<Health>().Damage(damage);

            other.gameObject.GetComponent<EnemyMovement>().canMoveKnockback = false;
            other.gameObject.GetComponent<EnemyMovement>().canMoveAfterKnockback = knockbackDuration;

            //
            Vector2 knockbackDirection = GameObject.FindGameObjectWithTag("Player").transform.position - other.gameObject.transform.position;

            // Add knockback effect to the enemy
            other.gameObject.GetComponent<Rigidbody2D>().velocity = -knockbackDirection.normalized * knockbackMultiplier;
        }
        else
        {
            return;
        }
    }
}
