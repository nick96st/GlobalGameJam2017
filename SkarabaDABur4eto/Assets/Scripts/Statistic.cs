using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour {


	[SerializeField]
	int starCounter;
	[SerializeField]
	int deathCounter;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void starCollected() {
		starCounter++;
	}
		
	public void addDeath() {
		deathCounter++;
	}
		
}
