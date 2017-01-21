﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private GameObject platform;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;
	// Use this for initialization
	void Start () {
        platform = this.gameObject;
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if(platform.transform.position== currentPoint.position)
        {
            pointSelection++;
            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }
        }
        
        currentPoint = points[pointSelection];
    }
}
