using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIron : MonoBehaviour {

  public GameObject ironInstance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

      if (Input.GetKeyDown(KeyCode.I)) {
        ironInstance.GetComponent<IronWobble>().HitObject();
      }
  }
}
