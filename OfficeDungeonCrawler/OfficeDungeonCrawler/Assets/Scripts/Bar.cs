/*
Author: Myles Busig
Contributors: N/A
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
	// The maximum amount
	public float max = 10.0f;
	// The current amount
	public float current;
	// The maximum width of the bar
	public float width = 8.0f;
	// The speed to change the bar
	public float changeSpeed = 1.0f;
	// The color when the bar is low
	public Color lowColor = Color.red;
	// The color when the bar is high
	public Color highColor = Color.green;

	// The image component of the bar
	Image image;

	void Start()
	{
		// Set current to max
		current = max;

		// Get the image component
		image = GetComponent<Image>();
	}
	
	void Update()
	{
		// Calculate the precentage
		float precentage = (max / 100) * current;

		// Calculate the current size
		float currentSize = width * precentage;

		// Calculate the current color
		Color currentColor = (lowColor * (1 - precentage)) + (highColor * precentage);
		// Set the alpha to 1
		currentColor.a = 1.0f;

		// Scale the bar
		transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(currentSize, transform.localScale.y), Time.deltaTime * changeSpeed);

		// Set the bar color
		image.color = Color.Lerp(image.color, currentColor, Time.deltaTime * changeSpeed);
	}
}
