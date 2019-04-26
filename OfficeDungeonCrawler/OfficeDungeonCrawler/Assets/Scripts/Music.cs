using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
	public AudioClip arrival;
	public AudioClip survival;
	public AudioClip revival;

	AudioSource src;

	string lastLevel = "";

	void Start()
	{
		DontDestroyOnLoad(this);

		src = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		string current = SceneManager.GetActiveScene().name;

		if (current != lastLevel)
		{
			if (src.clip != arrival && (current == "SplashScreen" || current == "MainMenu" || current == "Credits" || current == "Tutorial" || current == "Tutorial3"))
			{
				src.clip = arrival;

				src.Play();
			}
			else if (src.clip != survival && (current == "CubicleRoom1" || current == "Tutorial1" || current == "Tutorial2"))
			{
				src.clip = survival;

				src.Play();
			}
		}

		lastLevel = current;
	}
}
