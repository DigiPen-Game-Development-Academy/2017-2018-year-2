/*
Author: Kevin P
Contributors: Myles B
Date Last Modified: 3/22/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPMeter : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    Health health;
    public Sprite heart;
    public Sprite halfHeart;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            //Debug.Log((i * 2) + " < " + health.currentHealth);

            Image image = hearts[i].GetComponent<Image>();

            // full heart
            if (i * 2 < health.currentHealth - 1)
            {
                //Debug.Log("Index: " + i + " is ful");
                image.sprite = heart;
                image.color = Color.white;
            }
            // half heart
            else if (i * 2 < health.currentHealth)
            {
                //Debug.Log("Index: " + i + " is half ful");
                image.sprite = halfHeart;
                image.color = Color.white;
            }
            // no heart
            else
            {
                //Debug.Log("Index: " + i + " is not ful");
                image.sprite = null;
                image.color = Color.clear;
            }
        }
    }
}