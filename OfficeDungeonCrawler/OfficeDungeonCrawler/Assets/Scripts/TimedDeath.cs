/*
Author: Luke Taranowski
Contributors: NA
Last Edited: 1/29/219
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedDeath : MonoBehaviour
{
    // Public variable we can edit in inspector
    public float deathTimer;
    // Private variable we can edit without effecting the public variable
    private float timer;
	public GameObject deathScreen;
	GameObject vignete;
    // Start is called before the first frame update
    void Start()
    {
		vignete = GameObject.Find("UIDamageScreen");

        // Set the private variable to the public one
        timer = deathTimer;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the timer has run out
        if (timer <= 0)
        {
			if (vignete != null)
			{
				if (vignete.GetComponent<Image>() != null)
					Debug.Log("Not null");
				vignete.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, vignete.GetComponent<Image>().color.a);
			}
			if (deathScreen != null)
				Instantiate(deathScreen, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -2.0f), Quaternion.Euler(Vector3.zero));
            // destroys this object
            Destroy(gameObject);
        }
        else // decrease the timer
            timer -= Time.deltaTime;
    }
}
