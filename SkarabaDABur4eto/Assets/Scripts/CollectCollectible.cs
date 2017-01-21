using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollectible : MonoBehaviour {

	[SerializeField]
	Statistic statistic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			statistic.starCollected ();
			gameObject.SetActive (false);
		}
	}
}
