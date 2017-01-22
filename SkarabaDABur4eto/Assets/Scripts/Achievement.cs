using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {

	private string name;

	public string Name {
		get { return name; }
		set { name = value; }
	}

	private string description;
	public string Description {
		get { return description; }
		set { description = value; }
	}
	private int points;
	private bool unlocked;
	private GameObject thisAchievement;
	private List<Achievement> dependencies = new List<Achievement>();

	private string child;
	public string Child {
		get { return child; }
		set { child = value; }
	}

	public Achievement (string name, string description,GameObject thisAchievement) {
		this.name = name;
		this.points = 1;
		this.description = description;
		this.unlocked = false;
		this.thisAchievement = thisAchievement;
		LoadAchievement ();
	}
	public void AddDependency(Achievement dependency) {
		dependencies.Add (dependency);
	}

	public bool EarnAchievement(){
		if (!unlocked && !dependencies.Exists(i => i.unlocked == false ))  {
			thisAchievement.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
			SaveAchievement (true);
			if (child != null) {
				AchievementManager.Instance.EarnAchievement (child);
			}
			return true;
		}
		return false;
	}

	public void SaveAchievement(bool value) {
		unlocked = value;
		int tmpPoints = PlayerPrefs.GetInt ("Points");
		PlayerPrefs.SetInt ("Points", tmpPoints += points);
		PlayerPrefs.SetInt (name, value ? 1 : 0);
		PlayerPrefs.Save ();

	}

	public void LoadAchievement() {
		unlocked = PlayerPrefs.GetInt (name) == 1 ? true : false;
		if (unlocked) {
			AchievementManager.Instance.textPoints.text = "Points: " + PlayerPrefs.GetInt ("Points");
			thisAchievement.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
		}
			 
	}
	// Update is called once per frame
	void Update () {
		
	}
}
