﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public float size = 5.0f;
	public Color highColor = Color.green;
	public Color lowColor = Color.red;
	public float changeSpeed = 3.0f;
	public float current = 0.0f;
	public float max = 0.0f;
	public bool updateActive = true;
	public Vector3 offset = Vector3.zero;

	Health health;

	public GameObject healthBarAnchor;
	public GameObject healthBar;
	public GameObject allHealthBar;
	SpriteRenderer spriteRenderer;

	public void Start()
	{
		health = GetComponent<Health>();
		spriteRenderer = healthBar.GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		if (health == null)
			return;

		if (updateActive)
		{
			max = health.maxHealth;
			current = health.currentHealth;
		}
		
		
		allHealthBar.transform.position = transform.position + offset;

		//healthBarAnchor.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		//transform.Find("HealthbarBGAnchor").transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

		// Calculate the precentage
		float precentage = ((100.0f / max) * current) / 100.0f;
		
		// Calculate the current size
		float currentSize = size * precentage;

		// Calculate the current color
		Color currentColor = (lowColor * (1 - precentage)) + (highColor * precentage);
		// Set the alpha to 1
		currentColor.a = 1.0f;

		// Scale the bar
		healthBarAnchor.transform.localScale = Vector2.Lerp(healthBarAnchor.transform.localScale, new Vector2(currentSize, healthBarAnchor.transform.localScale.y), Time.deltaTime * changeSpeed);

		// Set the bar color
		spriteRenderer.color = Color.Lerp(spriteRenderer.color, currentColor, Time.deltaTime * changeSpeed);
	}
}
