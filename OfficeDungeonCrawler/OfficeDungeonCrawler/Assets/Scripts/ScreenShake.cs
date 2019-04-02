using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public GameObject mainCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void shakeCamera(float intensity, float time)
    {
        time = 0.0f;
        float length = 1.0f;
        for (time = 0; time < length; time++)
        {
            if (time == 1)
            {
                float xTransform = Random.Range(-intensity, intensity);
                float yTransform = Random.Range(-intensity, intensity);
                mainCamera.transform.position += new Vector3(xTransform, yTransform, 0);
            }
        }
    }
}