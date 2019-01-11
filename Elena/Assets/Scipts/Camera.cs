using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    public GameObject Player;
    public Vector3 offset = new Vector3(0,5,0);
   
   
    // Use this for initialization
    void Start()
    {
        target = Player.transform;

    }

    // Update is called once per frame
    void Update()
    {
      this.transform.position = target.transform.position + offset;
    }
}
