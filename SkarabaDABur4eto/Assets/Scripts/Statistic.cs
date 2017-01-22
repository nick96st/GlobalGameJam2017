using System.Collections;
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

	[SerializeField]
	int dabsCounter;

	[SerializeField]
	int jumpsCounter;

	[SerializeField]
	int shotsCounter;

	[SerializeField]
	bool gameWon;

	[SerializeField]
	bool checkpointReached;
	// Use this for initialization
	void Start () {
		checkpointReached = false;
		gameWon = false;
	}
	
	// Update is called once per frame



	void Update () {
		UpdateTimerUI ();
	}

	public bool checkpointStatus(){
		return checkpointReached;
	}
	public bool gameStatus(){
		return gameWon;
	}
	public int getShots(){
		return shotsCounter;
	}
	public int getJumps(){
		return jumpsCounter;
	}
	public int getDabs(){
		return dabsCounter;
	}
	public int getDeathCounter(){
		return deathCounter;
	}
	public int getStarCounter(){
		return starCounter;
	}

	public void ShotMade(){
		shotsCounter++;
	}

	public void JumpMade(){
		jumpsCounter++;
	}

	public void DabMade(){
		dabsCounter++;
	}

	public void WinGame(){
		gameWon = true;
	}
		
	public void CheckpointReached(){
		checkpointReached = true;
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