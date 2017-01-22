using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "mPlatform")
        {
            transform.parent = null;
        }
    }
}
