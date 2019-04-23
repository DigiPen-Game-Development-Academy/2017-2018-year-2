using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialSpriteEvent
{
	Walk,
	Dash,
	Attack,
	UseItem
}

public class TutorialSprite : MonoBehaviour
{
	public TutorialSpriteEvent tEvent = TutorialSpriteEvent.Walk;
	public float time = 10.0f;
	public float lerpSpeed = 1.5f;
	public float lerpOutSpeed = 1.5f;
	public float maxAlha = 0.5f;
	float timeTillShow;
	bool completed = false;

	SpriteRenderer sr;

	void Start()
	{
		timeTillShow = time;

		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		timeTillShow -= Time.deltaTime;

		switch (tEvent)
		{
			case TutorialSpriteEvent.Walk:
				if (Input.GetKeyDown(Settings.KeyBinds.left) || Input.GetKeyDown(Settings.KeyBinds.right) || Input.GetKeyDown(Settings.KeyBinds.up) || Input.GetKeyDown(Settings.KeyBinds.down))
					completed = true;
				break;
			case TutorialSpriteEvent.Dash:
				if (Input.GetKeyDown(Settings.KeyBinds.dash) || Input.GetKeyDown(KeyCode.Space))
					completed = true;
				break;
			case TutorialSpriteEvent.Attack:
				if (Input.GetMouseButtonDown(0))
					completed = true;
				break;
			case TutorialSpriteEvent.UseItem:
				if (Input.GetMouseButtonDown(1))
					completed = true;
				break;
			default:
				break;
		}

		if (timeTillShow <= 0.0f && !completed)
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(sr.color.a, maxAlha, lerpSpeed * Time.deltaTime));
		else
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(sr.color.a, 0.0f, lerpOutSpeed * Time.deltaTime));
	}
}
