using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	public string itemID;
	public int itemAmount;
	public AudioClip pickupSound;

	GameObject player;
	Inventory inventory;
	SpriteRenderer spriteRenderer;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
		if (player != null)
			inventory = player.GetComponent<Inventory>();

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (inventory.GiveItem(itemID, itemAmount))
			{
				GameObject.Find("KeyAudio").GetComponent<AudioSource>().PlayOneShot(pickupSound);
				Destroy(gameObject);
			}
		}
	}

	void Update()
	{
		if (inventory != null)
		{
			foreach (Item item in inventory.itemBases)
			{
				if (item.id == itemID)
					spriteRenderer.sprite = item.sprite;
			}
		}
	}
}
