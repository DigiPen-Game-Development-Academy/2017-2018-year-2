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
	public List<GameObject> slotCounts = new List<GameObject>();

	public Sprite slotBackgroundSelected;
	public Sprite slotBackgroundDeselected;
	public Sprite slotBackgroundDeselectedL;
	public Sprite slotBackgroundDeselectedR;

	Health health;

	void Start()
	{
		health = GetComponent<Health>();

		//GiveItem("test1", 1);
		//GiveItem("test2", 1);
		//GiveItem("test3", 1);
		//GiveItem("test4", 1);
		//GiveItem("test5", 1);
	}

	//int it = 0;

    void Update()
	{
		//if (Input.GetKeyDown(KeyCode.R))
		//{
		//	GiveItem(itemBases[it].id, 1);
		//	++it;
		//}

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
		
		if (Input.GetMouseButtonDown(1))
		{
			if (items[selectedSlot].itemType == ItemType.HealthItem)
			{
				health.Heal(items[selectedSlot].health);
				RemoveItem(items[selectedSlot].id, 1);
			}
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
			Image image = slots[i].GetComponent<Image>();

			if (i < items.Count)
			{
				image.sprite = items[i].sprite;
				image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
			}
			else
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
			}
		}

		for (int i = 0; i < slotCounts.Count; ++i)
		{
			Text text = slotCounts[i].GetComponent<Text>();

			if (i < items.Count)
			{
				if (items[i].count == 1)
					text.text = "";
				else
					text.text = items[i].count.ToString();
			}
			else
				text.text = "";
		}
	}

	public bool GiveItem(string id, int count)
	{
		foreach (Item item in items)
		{
			if (item.id == id)
			{
				item.count += count;
				return true;
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
				return false;
			}

			newItem.count = count;

			items.Add(newItem);

			return true;
		}

		Debug.Log("Inventory full!");
		return false;
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
