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

	new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		Vector3 input = Vector3.zero;
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			input.x += 1;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			input.x -= 1;
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			input.y += 1;
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			input.y -= 1;

		transform.Rotate(Vector3.forward, turnSpeed * input.x);

		Vector3 velocity = transform.up * input.y * speed;
		Debug.Log("vel: " + Mathf.Round(input.y));
		if (Mathf.Round(input.y) == 0.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * decell);
		else if (Mathf.Round(input.y) == 1.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * accel);
		else if (Mathf.Round(input.y) == -1.0f)
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, Time.deltaTime * reverseAccel);
	}
}
