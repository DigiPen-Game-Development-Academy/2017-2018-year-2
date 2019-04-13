using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
	public int breakLevel = 0;
	public List<Sprite> sprites = new List<Sprite>();
	public bool canFullDestroy = true;
	public AudioClip breakSound;
	public AudioClip finalBreakSound;

	SpriteRenderer sr;
	int lastBreakLevel = 0;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		if (breakLevel < sprites.Count)
		{
			if (breakLevel != lastBreakLevel)
				GameObject.Find("KeyAudio").GetComponent<AudioSource>().PlayOneShot(breakSound);

			sr.sprite = sprites[breakLevel];
		}
		else
		{
			sr.sprite = sprites[sprites.Count - 1];

			if (canFullDestroy)
			{
				GameObject.Find("KeyAudio").GetComponent<AudioSource>().PlayOneShot(finalBreakSound);

				Destroy(gameObject);
			}
		}

		lastBreakLevel = breakLevel;
	}
}
