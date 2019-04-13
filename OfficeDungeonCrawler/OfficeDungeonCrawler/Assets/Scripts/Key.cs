using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public GameObject door;
	public AudioClip unlockSound;

	void Start()
	{
		
	}
	
	void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			door.GetComponent<DoorScript>().locked = false;
			GameObject.Find("KeyAudio").GetComponent<AudioSource>().PlayOneShot(unlockSound, 2.0f);
			Destroy(gameObject);
		}
	}
}
