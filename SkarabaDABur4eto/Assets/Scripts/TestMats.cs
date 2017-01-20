using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMats : MonoBehaviour {

  public GameObject VibInstance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
    if(Input.GetKeyDown(KeyCode.V)) {
      VibInstance.GetComponent<Vibranium>().HitObject();
    }
	}
}
