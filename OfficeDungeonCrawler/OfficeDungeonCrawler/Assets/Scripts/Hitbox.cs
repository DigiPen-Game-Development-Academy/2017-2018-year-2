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
	void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
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
        }
        else
        {
            return;
        }
    }
}
