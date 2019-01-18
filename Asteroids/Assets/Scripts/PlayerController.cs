using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 3.0f;
	public float turnSpeed = 2.0f;
	public float accel = 3.0f;
	public float reverseAccel = 3.0f;
	public float decell = 1.0f;

	public float fireRate = 0.5f;
	float timeTillFire = 0.0f;
	public float projectileDistance = 1.0f;
	public GameObject projectile;

	public GameObject playerDead;

	new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		// Direction input vector
		Vector3 input = Vector3.zero;

		// Get input
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			input.x += 1;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			input.x -= 1;
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			input.y += 1;
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			input.y -= 1;

		// Rotate
		transform.Rotate(Vector3.forward, turnSpeed * input.x);

		// Move
		Vector3 velocity = transform.up * input.y * speed;
		if (Mathf.Round(input.y) == 0.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * decell);
		else if (Mathf.Round(input.y) == 1.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * accel);
		else if (Mathf.Round(input.y) == -1.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * reverseAccel);

		// Decrease timeTillFire
		timeTillFire -= Time.deltaTime;

		// If space is pressed
		if (Input.GetKeyDown(KeyCode.Space) && timeTillFire <= 0.0f)
		{
			GameObject newProjectile = Instantiate(projectile, transform.position + (transform.up * projectileDistance), transform.rotation);
			newProjectile.GetComponent<Projectile>().direction = transform.up;

			// Reset timeTillFire
			timeTillFire = fireRate;
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Asteroids")
		{
			--Score.lives;
			Debug.Log("Lives: " + Score.lives);
			Instantiate(playerDead, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
