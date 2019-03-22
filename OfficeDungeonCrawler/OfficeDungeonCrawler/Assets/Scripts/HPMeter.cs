/*
Author: Kevin P
Contributors: 
Date Last Modified: 3/19/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPMeter : MonoBehaviour
{
    [HideInInspector]
    public List<Item> health = new List<Item>();

    public List<GameObject> slots = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (UnityEditor.Build.Player.collision = FindObjectOfType<StaplerAttack>)
        {
            for (int i = 0; i < slots.Count; ++i)
            {
                Image image = slots[i].GetComponent<Image>();

                if (i < health.Count)
                {
                    image.sprite = health[i].sprite;
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
                }
                else
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
                }
            }
        }
    }

    public void LoseHP(string id, int count)
    {
        foreach (Item hP in health)
        {
            if (hP.id == id)
            {
                hP.count -= count;

                if (hP.count <= 0)
                    health.Remove(hP);

                return;
            }
        }
    }
}
