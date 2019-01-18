using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControllerScript : MonoBehaviour
{
    public GameObject nextAsteroid;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void OnTriggerEnter(Collider other)
    {
        // If you collide with another asteroid
        if (other.gameObject.tag == "Asteroids")
        {
            // Do nothing
            return;
        }
        else // Else spawn two asteroids with a random direction and a forward velocity, then delete the old asteroid.
        {
            // If we didn't set a next asteroid, that means we are on the smallest asteroid
            if (!nextAsteroid)
            {
                // So destroy the object
                Destroy(gameObject);
            }
            else
            {
                // We aren't the smallest asteroid yet so split apart
                for (int i = 0; i < 2; i++)
                {
                    // Give spawned asteroids random rotation
                    float z = Random.Range(-180, 180);
                    Quaternion rotation = Quaternion.Euler(0, 0, z);

                    GameObject createdAsteroid = Instantiate(nextAsteroid, transform.position, rotation);

                    // Give spawned asteroids a random forward velocity
                    float newVelocity = Random.Range(3, 6);
                    createdAsteroid.GetComponent<Rigidbody>().velocity = -createdAsteroid.transform.up * newVelocity;
                }
            }
            Destroy(gameObject);
        }
    }

}
