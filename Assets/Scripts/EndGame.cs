using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public GameObject loseText;

	void Start () {
		loseText.GetComponent<UnityEngine.UI.Text> ().text = "You lose!";

		CheckHighscore ();

		Debug.Log ("Max Score: " + PlayerPrefs.GetInt ("maxScore"));
	}

	void Update () {
		if (Input.GetKey(KeyCode.A))
			Utilities.ChangeScene (1, 1.0f);
	}

	void CheckHighscore () {
		// If there is no register of a previous pontuation or if the current score is higher than the previous one, set the new highscore
		if (!PlayerPrefs.HasKey ("maxScore")) {
			PlayerPrefs.SetInt ("maxScore", PlayerPrefs.GetInt ("currentScore"));
			return;
		}

		if (PlayerPrefs.GetInt ("maxScore") < PlayerPrefs.GetInt ("currentScore")) {
			PlayerPrefs.SetInt ("maxScore", PlayerPrefs.GetInt ("currentScore"));
			return;
		}
	}

}
