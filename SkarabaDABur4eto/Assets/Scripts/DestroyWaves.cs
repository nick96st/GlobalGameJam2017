﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWaves : MonoBehaviour
{
    private void Update()
    {
        Destroy(this.gameObject, 3.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Environment"))
        {
            Destroy(this.gameObject);
        }
    }
}