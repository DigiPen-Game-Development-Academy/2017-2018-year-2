using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCooler : MonoBehaviour
{
	public AudioClip dispenseSound;
	public AudioClip outSound;
	public GameObject itemPickup;
	public int maxCount = 3;
	public Vector2 offset;
	public Vector2 range;
	int left = 0;

	void Start()
	{
		left = maxCount;
	}

	void Update()
	{

	}

	public void Dispense()
	{
		if (left <= 0)
		{
			GetComponent<AudioSource>().PlayOneShot(outSound);
			return;
		}

		ItemPickup newItem = Instantiate(itemPickup, transform.position - (Vector3)offset + new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), 0), transform.rotation).GetComponent<ItemPickup>();

		newItem.itemID = "water";
		newItem.itemAmount = 1;

		GetComponent<AudioSource>().PlayOneShot(dispenseSound);

		--left;
	}
}
