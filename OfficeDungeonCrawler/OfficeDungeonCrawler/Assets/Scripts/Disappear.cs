using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
	public float speed = 2.0f;
	public float range = 0.1f;

	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(spriteRenderer.color.a, 0.0f, Time.deltaTime * speed));

		if (spriteRenderer.color.a <= range)
			Destroy(gameObject);
	}
}
