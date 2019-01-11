using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FireMode
{
	Cardinal,
	Facing,
	Mouse,
	FacingT,
	MouseT
}
public enum Direction
{
	F,
	B,
	FB,
	L,
	R,
	LR,
	A,
	D
}
public enum CameraMode
{
	FirstPerson,
	TopDown
}

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	public float accel = 3.0f;
	public float walkSpeed = 3.0f;
	public float runSpeed = 5.0f;
	public float sensitivity = 7.0f;
	public float projectileStartDistance = 1.0f;

	public GameObject projectile = null;
	public float maxFireRate = 0.2f;
	float timeTillCanFire = 0.0f;

	public FireMode fireMode = FireMode.Cardinal;
	public Direction direction = Direction.F;
	public CameraMode cameraMode = CameraMode.FirstPerson;
	public Text fireModeTxt;
	public Text directionTxt;
	public Text cameraModeTxt;

	new public GameObject camera;
	public float cameraDistance = 4.0f;

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

		if (Input.GetKeyDown(KeyCode.C))
		{
			if (cameraMode == CameraMode.FirstPerson)
			{
				cameraMode = CameraMode.TopDown;

				camera.transform.SetParent(null);
			}
			else if (cameraMode == CameraMode.TopDown)
			{
				cameraMode = CameraMode.FirstPerson;

				camera.transform.SetParent(transform);
			}
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			int i = (int)fireMode + 1;
			if (Enum.IsDefined(typeof(FireMode), i))
				fireMode = (FireMode)i;
			else
				fireMode = FireMode.Cardinal;
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			int i = (int)direction + 1;
			if (Enum.IsDefined(typeof(Direction), i))
				direction = (Direction)i;
			else
				direction = Direction.F;
		}

		Vector3 newVelocity = Vector3.zero;

		if (cameraMode == CameraMode.FirstPerson)
		{
			camera.transform.localRotation = Quaternion.Euler(Vector3.zero);
			camera.transform.localPosition = Vector3.zero;

			input = transform.TransformDirection(input);
			newVelocity = new Vector3(0.0f, rigidbody.velocity.y, 0.0f) + (input * currentSpeed);
		}
		else if (cameraMode == CameraMode.TopDown)
		{
			camera.transform.position = transform.position + Vector3.up * cameraDistance;
			camera.transform.LookAt(transform.position);

			newVelocity = input * currentSpeed;
		}

		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, newVelocity, accel * Time.deltaTime);

		rigidbody.maxAngularVelocity = 0;
		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * sensitivity);

		//Debug.Log("forward: " + transform.forward);

		if (Input.GetMouseButton(0) && timeTillCanFire <= 0.0f)
		{
			//GameObject newProjectile = Instantiate(projectile, transform.position + (transform.forward * 2), transform.rotation * Quaternion.Euler(90.0f, 0.0f, 0.0f));
			Shoot(transform.position, transform.forward);

			timeTillCanFire = maxFireRate;
		}

		fireModeTxt.text = "FireMode: " + fireMode;
		directionTxt.text = "Direction: " + direction;
		cameraModeTxt.text = "CameraMode: " + cameraMode;
	}

	public GameObject Shoot(Vector3 position, Vector3 direction)
	{
		GameObject newProjectile = Instantiate(projectile, transform.position + (direction * projectileStartDistance), Quaternion.Euler(Vector3.Cross(Vector3.up, direction)) * Quaternion.Euler(90.0f, 0.0f, 0.0f));
		
		//Debug.Log("Rotation: " + (Quaternion.Euler(direction) * Quaternion.Euler(90.0f, 0.0f, 0.0f)));
		Debug.Log("Direction: " + direction);

		return newProjectile;
	}
}
