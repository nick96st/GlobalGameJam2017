using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	[SerializeField]
	float rotationX;
	[SerializeField]
	float rotationY;
	[SerializeField]
	float rotationZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (rotationX, rotationY, rotationZ) * Time.deltaTime);
	}
}
