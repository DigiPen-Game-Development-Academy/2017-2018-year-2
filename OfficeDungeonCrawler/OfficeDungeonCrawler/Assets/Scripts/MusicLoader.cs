﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoader : MonoBehaviour
{
	void Start()
	{
		if (GameObject.Find("Music") == null)
			SceneManager.LoadScene("Music", LoadSceneMode.Additive);
	}
	
	void Update()
	{
		
	}
}
