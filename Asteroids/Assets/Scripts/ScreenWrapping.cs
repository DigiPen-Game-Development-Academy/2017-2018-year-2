using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    public float leftConstraint;
    public float rightConstraint;
    public float upConstraint;
    public float downConstraint;

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x < leftConstraint)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, 0);
        }
        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, 0);
        }

        if (transform.position.y < downConstraint)
        {
            transform.position = new Vector3(transform.position.x, upConstraint, 0);
        }
        if (transform.position.y > upConstraint)
        {
            transform.position = new Vector3(transform.position.x, downConstraint, 0);
        }
    }
}
