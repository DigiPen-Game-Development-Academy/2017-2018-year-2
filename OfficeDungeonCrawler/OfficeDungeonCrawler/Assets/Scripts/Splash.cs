using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
	public float speed = 0.02f;
	public float stayTime = 2.0f;
	public float delay = 0.0f;
	float time = 0.0f;
	public string level;
	public float switchDelay = 1.0f;

	bool faded = false;

	SpriteRenderer sr;
	TextMesh t;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		t = GetComponent<TextMesh>();
	}
	
	void Update()
	{
		if (time < delay)
		{
			time += Time.deltaTime;
			return;
		}

		if (sr != null)
		{
			if (sr.color.a >= 1.0f)
				faded = true;
		}
		if (t != null)
		{
			if (t.color.a >= 1.0f)
				faded = true;
		}

		if (!faded)
		{
			if (sr != null)
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + speed);
			if (t != null)
				t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + speed);
		}
		else
			time += Time.deltaTime;

		if (time >= delay + stayTime)
		{
			if (sr != null)
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - speed);
			if (t != null)
				t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - speed);
		}

		if (sr != null)
		{
			if (sr.color.a <= 0.0f && faded && time >= delay + stayTime + switchDelay && level != "")
				SceneManager.LoadScene(level);
		}
		if (t != null)
		{
			if (t.color.a <= 0.0f && faded && time >= delay + stayTime + switchDelay && level != "")
				SceneManager.LoadScene(level);
		}
	}
}
