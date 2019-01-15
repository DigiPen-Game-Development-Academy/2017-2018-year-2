using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControllerScript : MonoBehaviour
{
    GameObject lAsteroid;
    GameObject mAsteroid;
    GameObject sAsteroid;

    Rigidbody rigidbody;

    float sizeTracker = 0;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        // If you collide with another asteroid
        if(other.gameObject.tag == "Asteroids")
        {
            // Do nothing
            return;
        }
        else
        {
            float z = Random.Range(-Mathf.PI, Mathf.PI);
            Quaternion rotation = Quaternion.Euler(0, 0, z);
            Instantiate(mAsteroid, transform.position, rotation);

            float zvelocity = Random.Range(-5, 5);
            float xvelocity = Random.Range(-5, 5);
            rigidbody.velocity = new Vector3(zvelocity, xvelocity, 0);
        }
    }

}
