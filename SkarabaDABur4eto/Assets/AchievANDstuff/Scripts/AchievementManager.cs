using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {
	[SerializeField]
	Statistic dataStatistic;
	[SerializeField]
	GameObject achievementPrefab;
	[SerializeField]
	GameObject visualAchievement;
	[SerializeField]
	GameObject achievementMenu;
	[SerializeField] ScrollRect scrollRect;

	[SerializeField]
	int fadeTime;
	[SerializeField]
	int showTime;
	public Sprite unlockedSprite;
	private static AchievementManager instance;

	public static AchievementManager Instance {
		get { 
			if (instance == null) {
				instance = GameObject.FindObjectOfType<AchievementManager>();
			}
			return AchievementManager.instance; }
	}

	public Text textPoints;

	private AchievementButton activeButton;
	private GameObject allCategories;
	private Dictionary<string, Achievement> allAchievements = new Dictionary<string, Achievement>();

	// Use this for initialization
	void Start () {

		PlayerPrefs.DeleteAll (); 
		// Add achievments to GeneralAchievments //

		CreateAchievement ("GeneralAchievements", "Star collector", "Are those stars?");
		CreateAchievement ("Feats", "All star champion", "Collect all stars");
		CreateAchievement ("Feats", "All or nothing", "Win the game first time will all stars");
		CreateAchievement ("GeneralAchievements", "White boys can't jump", "Jump boy jump");
		CreateAchievement ("GeneralAchievements", "Bunny", "Jump, stop, jump"); 
		CreateAchievement ("GeneralAchievements", "ScarabaDABBER", "Dab!");
		CreateAchievement ("GeneralAchievements", "Vine Channel", "Dab x100");
		CreateAchievement ("GeneralAchievements", "GODLIKE", "Dab x 1000");
		CreateAchievement ("Feats", "LUDICROUS", "Dab 1,000,000 times or lie");
		CreateAchievement ("GeneralAchievements", "Boom", "Shoot your weapon");
		CreateAchievement ("GeneralAchievements", "Got moves!", "Try them out?", new string[]{"White boys can't jump","ScarabaDABBER","Boom"});
		CreateAchievement ("Feats", "Ninja", "Ninjas can triple jump");
		CreateAchievement ("GeneralAchievements", "Air dab", "Was this implemented?");
		CreateAchievement ("GeneralAchievements", "Save", "Reach a checkpoint");
		CreateAchievement ("GeneralAchievements", "WASTED", "GTA V STYLE");
		CreateAchievement ("Feats", "Not a noob. Promise.", "Die 1337 times");
		CreateAchievement ("GeneralAchievements", "Lost a hearth", "But not my love for music");
		CreateAchievement ("GeneralAchievements", "Neverending ammo", "You can shoot more than 10 times");
		CreateAchievement ("Feats", "Spam and waste of sound", "Just shoot like crazy");
		CreateAchievement ("Feats", "That's my JAM", "Win the game");

		//CreateAchievement ("G

		//.............................///

		setAllFalse();
		activeButton = GameObject.Find ("GeneralBtn").GetComponent<AchievementButton> ();
		activeButton.SetClicked ();
		achievementMenu.SetActive (false);

	}


	public void UpdateMenu()
	{
		if (Input.GetKeyDown(KeyCode.I)) {
			achievementMenu.SetActive (!achievementMenu.activeSelf);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			achievementMenu.SetActive (!achievementMenu.activeSelf);
		}

		if (dataStatistic.gameStatus ()) {
			EarnAchievement ("That's my JAM");
			if (dataStatistic.getStarCounter () == 5) {
				EarnAchievement ("All or nothing");
			}
		}

		if (dataStatistic.checkpointStatus ()) {
			EarnAchievement ("Save");
		}

		if (dataStatistic.getStarCounter() == 1) {
			EarnAchievement ("Star collector");
		}

		else if (dataStatistic.getStarCounter() == 5) {
			EarnAchievement ("All star champion");
		}

		if (dataStatistic.getJumps () == 1) {
			EarnAchievement ("White boys can't jump");
		}
		else if (dataStatistic.getJumps () == 2) {
			EarnAchievement ("Bunny");
		}
		if (dataStatistic.getDabs () == 1) {
			EarnAchievement ("ScarabaDABBER");
		}
		else if (dataStatistic.getDabs () == 100) {
			EarnAchievement ("VineChannel");
		}
		else if (dataStatistic.getDabs () == 1000) {
			EarnAchievement ("GODLIKE");
		}
		else if (dataStatistic.getDabs () == 1000000) {
			EarnAchievement ("LUDICROUS");
		}
		if (dataStatistic.getShots () == 1) {
			EarnAchievement ("Boom");
		}
		else if (dataStatistic.getShots () == 10) {
			EarnAchievement ("Neverending ammo");
		}

		if (dataStatistic.getDeathCounter () == 1) {
			EarnAchievement ("Lost a hearth");
		}
		else if (dataStatistic.getDeathCounter () == 3) {
			EarnAchievement ("WASTED");
		}

		else if (dataStatistic.getDeathCounter () == 1337) {
			EarnAchievement ("Not a noob. Promise.");
		}
	}

	public void EarnAchievement(string title){
		if (allAchievements [title].EarnAchievement ()) {
			// DO SOMETHING AWESOME!
			GameObject achievement = (GameObject)Instantiate(visualAchievement);
			SetAchievementInfo ("EarnAchievementCanvas", achievement, title);
			textPoints.text = "Points: " + PlayerPrefs.GetInt ("Points");
			StartCoroutine (FadeAchievement (achievement));
		}
	}

	public IEnumerator HideAchievement(GameObject achievement)
	{
		yield return new WaitForSeconds (3);
		Destroy(achievement);
	}

	void setAllFalse () {
		allCategories = GameObject.Find ("AchievementMask"); 
		Transform allCatTransform = allCategories.GetComponent<Transform> ();
		for (int i = 0; i < allCatTransform.childCount; i++) {
			allCategories.GetComponent<Transform> ().GetChild (i).gameObject.SetActive (false);
		}
	}

	public void CreateAchievement(string parent, string title, string description, string[] dependencies = null){
		GameObject achievement = Instantiate (achievementPrefab);
		Achievement newAchievement = new Achievement (name, description, achievement);
		allAchievements.Add(title, newAchievement);
		SetAchievementInfo (parent, achievement, title);

		if (dependencies != null) {
			foreach (string item in dependencies) {
				Achievement dependency;
				allAchievements.TryGetValue(item,out dependency);
				dependency.Child = title;
				newAchievement.AddDependency (dependency);

			}
		}
			
	}

	public void SetAchievementInfo(string parent, GameObject achievement, string title){

		achievement.GetComponent<Transform> ().SetParent (GameObject.Find (parent).GetComponent<Transform> ());
		achievement.GetComponent<Transform> ().GetChild (0).GetComponent<Text> ().text = title;
		achievement.GetComponent<Transform> ().GetChild (1).GetComponent<Text> ().text = allAchievements [title].Description;
	}
			
	public void ChangeCategory(GameObject button){
		AchievementButton achievementButton = button.GetComponent<AchievementButton> ();

		activeButton.UnSetClicked ();
		activeButton.achievementList.SetActive (false);

		scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform> ();
		achievementButton.SetClicked ();
		achievementButton.achievementList.SetActive (true);

		activeButton = achievementButton;
	}

	private IEnumerator FadeAchievement (GameObject achievement){
		CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup> ();

		float rate = 1.0f / fadeTime;
		int startAlpha = 0;
		int endAlpha = 1;


		for (int i = 0; i < 2; i++) {
			
			float progress = 0.0f;
			while (progress < 1.0) {
				canvasGroup.alpha = Mathf.Lerp (startAlpha, endAlpha, progress);
				progress += rate * Time.deltaTime;

				yield return null;
			}

			yield return new WaitForSeconds (showTime);
			startAlpha = 1;
			endAlpha = 0;
		}

		Destroy (achievement);

	}
}
