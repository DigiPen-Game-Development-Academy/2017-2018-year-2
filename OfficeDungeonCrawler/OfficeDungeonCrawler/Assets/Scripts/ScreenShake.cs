using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update(float intensity, float time)
    {

        float xTransform = Random.Range(-intensity, intensity);
        float yTransform = Random.Range(-intensity, intensity);
        gameObject.transform.position += new Vector3(xTransform, yTransform, 0);
    }
}
    