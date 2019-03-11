using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	NoUse = 0,
	MeleeWeapon = 1,
	RangedWeapon = 2,
	HealthItem = 3
}

[Serializable]
public class Item
{
	public string id;
	public ItemType itemType = ItemType.NoUse;

	public Sprite sprite;
	
	public int count = 1;
	public float damage = 1.0f;
	public float health = 1.0f;

	public Item(string id_, ItemType itemType_, float amount_, Sprite sprite_)
	{
		id = id_;
		itemType = itemType_;
		sprite = sprite_;

		if (itemType_ == ItemType.MeleeWeapon || itemType_ == ItemType.RangedWeapon)
			damage = amount_;
		else if (itemType_ == ItemType.HealthItem)
			health = amount_;
	}

	public Item(string id_, ItemType itemType_, float damage_, float health_, Sprite sprite_)
	{
		id = id_;
		itemType = itemType_;
		sprite = sprite_;
		
		damage = damage_;
		health = health_;
	}

	public Item Clone()
	{
		return new Item(id, itemType, damage, health, sprite);
	}
}
