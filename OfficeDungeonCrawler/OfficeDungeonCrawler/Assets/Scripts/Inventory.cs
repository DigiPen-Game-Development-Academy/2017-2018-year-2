using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[HideInInspector]
	public List<Item> items = new List<Item>();
	public List<Item> itemBases = new List<Item>();

	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;
	public GameObject slot4;
	public GameObject slot5;

	void Start()
	{
		
	}
	
	void Update()
	{
		
	}

	public void GiveItem(string id, int count)
	{
		foreach (Item item in items)
		{
			if (item.id == id)
			{
				item.count += count;
				return;
			}
		}

		if (items.Count < 5)
		{
			Item newItem = null;
			foreach (Item item in itemBases)
			{
				if (item.id == id)
					newItem = item.Clone();
			}

			if (newItem == null)
			{
				Debug.Log("No item with id " + id + " exists!");
				return;
			}

			newItem.count = count;

			items.Add(newItem);
		}
		else
			Debug.Log("Inventory full!");
	}

	public void RemoveItem(string id, int count)
	{
		foreach (Item item in items)
		{
			if (item.id == id)
			{
				item.count -= count;

				if (item.count <= 0)
					items.Remove(item);

				return;
			}
		}
	}

	public void Print()
	{
		string str = "Inv: [";
		for (int i = 0; i < items.Count; ++i)
		{
			str += "{" + items[i].id + ", " + items[i].count + "}";
			if (i < items.Count - 1)
				str += ", ";
		}
		str += "]";
		Debug.Log(str);
	}
}
