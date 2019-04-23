/*
Author: Myles Busig
Contributors: N/A
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{
	Locked,
	Lerped,
	Directional
}

public class CameraMovement : MonoBehaviour
{
	public GameObject target;
	public float speed = 3.0f;
	public float directionMultiplier = 2.5f;
	public CameraType type = CameraType.Lerped;
	public Vector2 screenShakeOffset = new Vector2(0.25f, 0.25f);
	public float screenShakeTime = 0.0f;

	PlayerMovement playerMovement;

	void Start()
	{
		playerMovement = target.GetComponent<PlayerMovement>();
	}
	
	void FixedUpdate()
	{
		if (target == null)
			return;

		screenShakeTime -= Time.deltaTime;

		Vector3 position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
		if (type == CameraType.Directional)
			position += (Vector3)(playerMovement.currentDirection * directionMultiplier);

		if (screenShakeTime > 0.0f)
			position += new Vector3(Random.Range(-screenShakeOffset.x, screenShakeOffset.x), Random.Range(-screenShakeOffset.y, screenShakeOffset.y), 0.0f);

		if (type == CameraType.Locked)
			transform.position = position;
		else
			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * speed);
	}
}
