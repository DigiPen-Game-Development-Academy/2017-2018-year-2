using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
	public float delayTime = 1.0f;

	public string gameLevel;
	public string gameOverLevel;

	void Start()
	{
		
	}
	
	void Update()
	{
		delayTime -= Time.deltaTime;

		if (delayTime <= 0.0f)
		{
			if (Score.lives <= 0)
				SceneManager.LoadScene(gameOverLevel, LoadSceneMode.Single);
			else
				SceneManager.LoadScene(gameLevel, LoadSceneMode.Single);
		}
	}
}
