using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    public Vector2 move = Vector2.right;
	public GameObject enemyDamagedParticleEffect;
	public float max = 0.0f;

	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x >= max)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			return;
		}

        GetComponent<Rigidbody2D>().velocity = move;
    }
	
	void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
			collision.gameObject.GetComponent<Health>().Damage(9001.0f);
		else if (collision.gameObject.GetComponent<Breakable>() != null)
		{
			collision.gameObject.GetComponent<Breakable>().breakLevel += 9001;

			Camera.main.GetComponent<CameraMovement>().screenShakeTime = 0.2f;

			Vector3 spawnPosition = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z + 10);
			// Spawn the particle effect
			Instantiate(enemyDamagedParticleEffect, spawnPosition, collision.gameObject.transform.rotation);
		}
    }
}