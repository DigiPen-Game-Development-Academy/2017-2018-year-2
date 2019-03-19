/*
Author; Luke Taranowski
Contributers;
Last Edited: 3/19/2019
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterScript : MonoBehaviour
{
    public GameObject projectile;
    GameObject player;

    public float detectionRange;
    public float firerate;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.right));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }
}
