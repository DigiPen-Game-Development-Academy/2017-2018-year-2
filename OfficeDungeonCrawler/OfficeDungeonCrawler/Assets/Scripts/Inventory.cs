using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	[HideInInspector]
	public List<Item> items = new List<Item>();
	public List<Item> itemBases = new List<Item>();

	public int selectedSlot = 0;

	public List<GameObject> slots = new List<GameObject>();
	public List<GameObject> slotBackgrounds = new List<GameObject>();

	public Sprite slotBackgroundSelected;
	public Sprite slotBackgroundDeselected;
	public Sprite slotBackgroundDeselectedL;
	public Sprite slotBackgroundDeselectedR;

	void Start()
	{
		GiveItem("test1", 1);
		GiveItem("test2", 1);
		GiveItem("test3", 1);
		GiveItem("test4", 1);
		GiveItem("test5", 1);
	}
	
	void Update()
	{
		Debug.Log("Slot: " + selectedSlot);

		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (selectedSlot > 0)
				--selectedSlot;
			else
				selectedSlot = slots.Count - 1;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (selectedSlot < slots.Count - 1)
				++selectedSlot;
			else
				selectedSlot = 0;
		}

		for (int i = 0; i < slotBackgrounds.Count; ++i)
		{
			if (i == selectedSlot)
				slotBackgrounds[i].GetComponent<Image>().sprite = slotBackgroundSelected;
			else
			{
				if (i == 0)
					slotBackgrounds[i].GetComponent<Image>().sprite = slotBackgroundDeselectedL;
				else if (i == slotBackgrounds.Count - 1)
					slotBackgrounds[i].GetComponent<Image>().sprite = slotBackgroundDeselectedR;
				else
					slotBackgrounds[i].GetComponent<Image>().sprite = slotBackgroundDeselected;
			}
		}

		for (int i = 0; i < slots.Count; ++i)
		{
			slots[i].GetComponent<Image>().sprite = items[i].sprite;
		}
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
