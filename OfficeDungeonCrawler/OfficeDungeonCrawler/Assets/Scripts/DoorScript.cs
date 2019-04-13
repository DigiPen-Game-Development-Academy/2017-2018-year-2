/*
Author: Luke Taranowsk
Contributors:
Date Last Modified: 3/8/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public string nextRoom;
	public bool locked = true;

	void Update()
	{
		if (locked)
			transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		else
			transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && !locked)
			SceneManager.LoadScene(nextRoom);
	}
}