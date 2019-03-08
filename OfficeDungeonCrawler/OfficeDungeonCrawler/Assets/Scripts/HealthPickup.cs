using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Collision Oncollide;

	// Use this for initialization
	void Start ()
    {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this);

            GameObject.Find("Player").Health + 1;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        collider();
	}
}
