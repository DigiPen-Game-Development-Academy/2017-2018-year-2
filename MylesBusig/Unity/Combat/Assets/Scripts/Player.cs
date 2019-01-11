using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

public class Game
{
	public static int score = 0;
	public static int highScore = 0;
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

	public Text scoreTxt;

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
				camera.transform.localRotation = Quaternion.Euler(Vector3.zero);
				camera.transform.localPosition = Vector3.zero;
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
			//camera.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * sensitivity, Space.Self);

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

		if (Input.GetMouseButton(0) && timeTillCanFire <= 0.0f)
		{
			Shoot(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.forward);
			
			timeTillCanFire = maxFireRate;
		}

		fireModeTxt.text = "FireMode: " + fireMode;
		directionTxt.text = "Direction: " + direction;
		cameraModeTxt.text = "CameraMode: " + cameraMode;
		scoreTxt.text = "Score: " + Game.score;
	}

	public GameObject Shoot(Vector3 position, Vector3 direction)
	{
		//0.0f, Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.z), 0.0f
		GameObject newProjectile = Instantiate(projectile, position + (direction * projectileStartDistance), Quaternion.FromToRotation(Vector3.up, direction));

		return newProjectile;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "CanShoot")
		{
			SceneManager.LoadScene("End");
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Collectable")
		{
			Game.score += collision.gameObject.GetComponent<Collectable>().score;
			Destroy(collision.gameObject);
		}
	}
}
