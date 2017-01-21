using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour {


	[SerializeField]
	int starCounter;
	[SerializeField]
	int deathCounter;
	[SerializeField]
	Text timerText;
	[SerializeField]
	float secondsCounter;
	[SerializeField]
	int minuteCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimerUI ();
	}

	public void starCollected() {
		starCounter++;
	}
		
	public void addDeath() {
		deathCounter++;
	}

	public void UpdateTimerUI() {
		secondsCounter += Time.deltaTime;
		timerText.text = minuteCounter + "m:" + (int)secondsCounter + "s";
		if (secondsCounter >= 60) {
			secondsCounter = 0;
			minuteCounter++;
		}
	}
		
}
