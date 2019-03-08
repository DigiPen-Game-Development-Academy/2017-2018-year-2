/*
Author: Luke Taranowsk
Contributors:
Date Last Modified: 3/8/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int nextRoomIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextRoomIndex);
    }
}