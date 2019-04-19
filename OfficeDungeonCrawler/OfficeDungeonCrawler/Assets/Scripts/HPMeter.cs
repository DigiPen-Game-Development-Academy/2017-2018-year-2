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
    GameObject player;
    public List<GameObject> hearts = new List<GameObject>();
    Health health;
    public Sprite heart;
    public Sprite halfHeart;

    float scaleTracker = 2f;

    bool beatingHeart;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        if (player.GetComponent<Health>().currentHealth <= 4)
            beatingHeart = true;
        else
        {
            beatingHeart = false;
            hearts[0].GetComponent<RectTransform>().localScale = Vector3.Lerp(hearts[0].GetComponent<RectTransform>().localScale, new Vector3(.8f, .8f, 1), Time.deltaTime * 3);
            hearts[1].GetComponent<RectTransform>().localScale = Vector3.Lerp(hearts[1].GetComponent<RectTransform>().localScale, new Vector3(.8f, .8f, 1), Time.deltaTime * 3);
        }

        if (beatingHeart)
        {
            if (hearts[0].GetComponent<RectTransform>().localScale.x > .825f)
                hearts[0].GetComponent<RectTransform>().localScale = Vector3.Lerp(hearts[0].GetComponent<RectTransform>().localScale, new Vector3(.8f, .8f, 1), Time.deltaTime * 3);
            else
                hearts[0].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);

            if (hearts[1].GetComponent<RectTransform>().localScale.x > .825f)
                hearts[1].GetComponent<RectTransform>().localScale = Vector3.Lerp(hearts[1].GetComponent<RectTransform>().localScale, new Vector3(.8f, .8f, 1), Time.deltaTime * 3);
            else
                hearts[1].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
        }

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