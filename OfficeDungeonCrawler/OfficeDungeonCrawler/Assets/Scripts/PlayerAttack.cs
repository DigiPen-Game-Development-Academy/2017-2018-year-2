/*
Author: Luke Taranowski
Contributors:NA
Last Edited: 1/29/2019s
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Attack()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Attack();

    }
}
