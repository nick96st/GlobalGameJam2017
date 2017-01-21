using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMats : MonoBehaviour {

  public GameObject VibInstance;
  public GameObject resInstance;
  public GameObject resInstance2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
    if(Input.GetKeyDown(KeyCode.V)) {
      VibInstance.GetComponent<Vibranium>().HitObject();
    }
    if(Input.GetKeyDown(KeyCode.R)) {
      resInstance.GetComponent<TripleResonance>().HitObject();
    }
    if (Input.GetKeyDown(KeyCode.E)) {
      resInstance2.GetComponent<TripleResonance>().HitObject();
    }
  }
}
