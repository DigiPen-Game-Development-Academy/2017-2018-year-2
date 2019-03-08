using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public string itemID;
    public int itemAmount;

	// Use this for initialization
	void Start ()
    {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            

            collision.gameObject.GetComponent<Inventory>().GiveItem(itemID, itemAmount);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
	}
}
