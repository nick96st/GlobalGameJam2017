using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour {
	

	public GameObject achievementList;
	[SerializeField]
	Sprite neutral, highlight;

	private Image imageSprite;
	void Awake() {
		imageSprite = this.gameObject.GetComponent<Image> ();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetClicked() {
		imageSprite.sprite = highlight;
		achievementList.SetActive (true);
	}

	public void UnSetClicked() {
		imageSprite.sprite = neutral;
		achievementList.SetActive (false);
	}
}
