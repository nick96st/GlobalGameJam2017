using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFunc : MonoBehaviour {

	[SerializeField]
	Canvas mainMenuCanvas;
	[SerializeField]
	AchievementManager achiev;
	[SerializeField]
	Statistic dataStatistic;

	GameObject menu;
	// Use this for initialization
	void Start () {
		menu = mainMenuCanvas.GetComponent<Transform> ().GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			menu.SetActive(!menu.activeSelf);
			dataStatistic.menuShift();
		}
	}
		
	public void startGame(){
		mainMenuCanvas.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
		dataStatistic.menuShift();
	}

	public void exitGame(){
		Application.Quit();
	}

	public void showAchiev(){
		achiev.UpdateMenu();
	}
}
