using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	public float accel = 3.0f;
	public float walkSpeed = 3.0f;
	public float runSpeed = 5.0f;
	public float sensitivity = 7.0f;
	public GameObject projectile = null;
	public float maxFireRate = 0.2f;
	float timeTillCanFire = 0.0f;

	new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update()
	{
		timeTillCanFire -= Time.deltaTime;

		float currentSpeed = walkSpeed;
		if (Input.GetKey(KeyCode.LeftShift))
			currentSpeed = runSpeed;

		Vector3 input = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
			input.z += 1;
		if (Input.GetKey(KeyCode.S))
			input.z += -1;
		if (Input.GetKey(KeyCode.A))
			input.x += -1;
		if (Input.GetKey(KeyCode.D))
			input.x += 1;

		input = transform.TransformDirection(input);
		Vector3 newVelocity = new Vector3(0.0f, rigidbody.velocity.y, 0.0f) + (input * currentSpeed);
		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, newVelocity, accel * Time.deltaTime);

		rigidbody.maxAngularVelocity = 0;
		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
		
		if (Input.GetMouseButton(0) && timeTillCanFire <= 0.0f)
		{
			GameObject newProjectile = Instantiate(projectile, transform.position + (transform.forward * 2), transform.rotation * Quaternion.Euler(90.0f, 0.0f, 0.0f));

			timeTillCanFire = maxFireRate;
		}
	}
}
