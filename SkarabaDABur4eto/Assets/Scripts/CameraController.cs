﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float cameraSpeed;

    public bool isFollowing = true;

    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;

    private void Start()
    {
        isFollowing = true;
    } 

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            GetComponent<Transform>().position = Vector3.Lerp(GetComponent<Transform>().position,
                          new Vector3(target.position.x + xOffset, target.position.y + yOffset, GetComponent<Transform>().position.z),
                          cameraSpeed * Time.deltaTime);
        }
	}
}
