using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	public float speed = 2.0f;
	public bool track = false;
	public GameObject target;
	public float despawnTime = 1.0f;

	new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		rigidbody.velocity = transform.up * speed;

		Destroy(gameObject, despawnTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "CanShoot")
		{
			Game.score += collision.gameObject.GetComponent<Shootable>().score;
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		else
			Destroy(gameObject);
	}
}
