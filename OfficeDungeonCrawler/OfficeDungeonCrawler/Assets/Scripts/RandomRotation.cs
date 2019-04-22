using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	public float min = -8.0f;
	public float max = 8.0f;

	void Start()
	{
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(min, max));
	}
	
	void Update()
	{
		
	}
}
