using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeWall : MonoBehaviour
{
    public Vector2 move = Vector2.right;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = move;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            //                                    ITZ OVAH NINE THOUSAAAAND!!!!
            collision.gameObject.GetComponent<Health>().Damage(9001.0f);
    }
}