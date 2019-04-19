using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroll : MonoBehaviour
{
	public float max = -100.0f;
	public float speed = 0.02f;

	void Start()
	{
		
	}
	
	void Update()
	{
		if (transform.position.y + speed <= max)
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
	}
}
