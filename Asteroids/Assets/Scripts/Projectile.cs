using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    new Rigidbody rigidbody;

    [HideInInspector]
    public Vector3 direction = Vector3.zero;
    [HideInInspector]
    public float speed = 10;
    public float duration = 10.00f;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction * speed;

        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}