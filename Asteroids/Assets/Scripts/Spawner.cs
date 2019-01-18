using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject asteroid;
	public float speedDivide = 4.0f;
	public float centerRadius = 2.0f;
	public float minRadius = 10.0f;
	public float radius = 20.0f;
	public float spawnRate = 3.0f;
	float timeTillSpawn = 0.0f;
	public float spawnRateDecrease = 0.1f;
	public float spawnRateDecreaseTime = 2.0f;
	float timeTillDecrease = 0.0f;
	public float minSpawnRate = 1.0f;
	
	void Start()
	{
		timeTillDecrease = spawnRateDecreaseTime;
	}
	
	void Update()
	{
		Debug.Log("Spwan Rate: " + spawnRate);

		timeTillSpawn -= Time.deltaTime;
		timeTillDecrease -= Time.deltaTime;

		if (timeTillDecrease <= 0.0f)
		{
			if (spawnRate - spawnRateDecrease >= minSpawnRate)
				spawnRate -= spawnRateDecrease;
			timeTillDecrease = spawnRateDecreaseTime;
		}

		if (timeTillSpawn <= 0.0f)
		{
			Vector3 position = Vector3.zero;

			position.x = Random.Range(minRadius, radius);
			position.y = Random.Range(minRadius, radius);
			if (Random.Range(0.0f, 1.0f) >= 0.5f)
				position.x = -position.x;
			if (Random.Range(0.0f, 1.0f) >= 0.5f)
				position.y = -position.y;

			GameObject newAsteroid = Instantiate(asteroid, position, Quaternion.Euler(Vector3.zero));
			newAsteroid.GetComponent<Rigidbody>().velocity = (-position + new Vector3(Random.Range(-centerRadius, centerRadius), Random.Range(-centerRadius, centerRadius), 0.0f)) / 4.0f;

			timeTillSpawn = spawnRate;
		}
	}
}
