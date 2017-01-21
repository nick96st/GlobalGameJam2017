<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour {


	[SerializeField]
	int starCounter;
	[SerializeField]
	Text starCounterText;

	[SerializeField]
	int deathCounter;
	[SerializeField]
	Text deathCounterText;

	[SerializeField]
	float secondsCounter;
	[SerializeField]
	int minuteCounter;
	[SerializeField]
	Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimerUI ();
	}

	public void starCollected() {
		starCounter++;
		starCounterText.text = "Stars Collected: " + starCounter;
	}
		
	public void addDeath() {
		deathCounter++;
		deathCounterText.text = "Lives Wasted: " + deathCounter;
	}

	public void UpdateTimerUI() {
		secondsCounter += Time.deltaTime;
		if (secondsCounter >= 60) {
			secondsCounter = 0;
			minuteCounter++;
		}
		timerText.text = "Time: ";

		if (minuteCounter < 10) {
			timerText.text += "0";
		}

		timerText.text += minuteCounter + ":";

		if (secondsCounter < 10) {
			timerText.text += "0";
		}
		timerText.text += (int)secondsCounter;

	}
		
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour {


	[SerializeField]
	int starCounter;
	[SerializeField]
	Text starCounterText;

	[SerializeField]
	int deathCounter;
	[SerializeField]
	Text deathCounterText;

	[SerializeField]
	float secondsCounter;
	[SerializeField]
	int minuteCounter;
	[SerializeField]
	Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimerUI ();
	}

	public void starCollected() {
		starCounter++;
		starCounterText.text = "Stars Collected: " + starCounter;
	}
		
	public void addDeath() {
		deathCounter++;
		deathCounterText.text = "Lives Wasted: " + deathCounter;
	}

	public void UpdateTimerUI() {
		secondsCounter += Time.deltaTime;
		if (secondsCounter >= 60) {
			secondsCounter = 0;
			minuteCounter++;
		}
		timerText.text = "Time: ";

		if (minuteCounter < 10) {
			timerText.text += "0";
		}

		timerText.text += minuteCounter + ":";

		if (secondsCounter < 10) {
			timerText.text += "0";
		}
		timerText.text += (int)secondsCounter;

	}
		
}
>>>>>>> 36a67a4ffce0245bbd771c9754c6947ef909eeaf
