/*
Author: Luke Taranowsk
Contributors:
Date Last Modified: 3/8/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum DoorUnlockMode
{
	None,
	ObjectDestroyed,
	LeftClick,
	RightClick,
	Dash
}

public class DoorScript : MonoBehaviour
{
	public string nextRoom;
	public bool locked = true;
	public DoorUnlockMode unlockMode = DoorUnlockMode.None;
	public GameObject obj = null;

	void Update()
	{
		if (unlockMode == DoorUnlockMode.ObjectDestroyed && obj == null)
			locked = false;
		if (unlockMode == DoorUnlockMode.LeftClick && Input.GetMouseButtonDown(0))
			locked = false;
		if (unlockMode == DoorUnlockMode.RightClick && Input.GetMouseButtonDown(1))
			locked = false;
		if (unlockMode == DoorUnlockMode.Dash && Input.GetKeyDown(KeyCode.LeftShift))
			locked = false;

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