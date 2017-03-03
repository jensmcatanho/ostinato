using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISystem : MonoBehaviour {
	// References to other systems.
	public GameObject audioSystem;
	public GameObject gameplaySystem;

	//
	public GameObject yellowButton;
	public GameObject greenButton;
	public GameObject redButton;
	public GameObject blueButton;

	// 
	public int score;
	public GameObject scoreDisplay;
	public GameObject countdownDisplay;

	//
	public bool isPatternShowing = false;

	void Update () {
		score = gameplaySystem.GetComponent<GameplaySystem> ().playerPoints;
		scoreDisplay.GetComponent<UnityEngine.UI.Text> ().text = "Score: " + score;
	}

	public IEnumerator ShowPattern() {
		int patternSize = gameplaySystem.GetComponent<GameplaySystem> ().pattern.Count;
		int bpm = gameplaySystem.GetComponent<GameplaySystem> ().bpm;

		isPatternShowing = true;

		if (patternSize == 1) {
			countdownDisplay.GetComponent<UnityEngine.UI.Text> ().text = "4";
			yield return new WaitForSeconds (60.0f / bpm);
			countdownDisplay.GetComponent<UnityEngine.UI.Text> ().text = "3";
			yield return new WaitForSeconds (60.0f / bpm);
			countdownDisplay.GetComponent<UnityEngine.UI.Text> ().text = "2";
			yield return new WaitForSeconds (60.0f / bpm);
			countdownDisplay.GetComponent<UnityEngine.UI.Text> ().text = "1";
			yield return new WaitForSeconds (60.0f / bpm);
			countdownDisplay.GetComponent<UnityEngine.UI.Text> ().text = "";
			
		} else {
			yield return new WaitForSeconds (1.5f);
		}

		for (int i = 0; i < patternSize; i++) {
			switch (gameplaySystem.GetComponent<GameplaySystem> ().pattern[i]) {
			case 1:
				yellowButton.GetComponent<AudioSource> ().Play ();
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.yellow;
				yield return new WaitForSeconds (60.0f/bpm);
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 2:
				greenButton.GetComponent<AudioSource> ().Play ();
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
				yield return new WaitForSeconds (60.0f/bpm);
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 3:
				redButton.GetComponent<AudioSource> ().Play ();
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
				yield return new WaitForSeconds (60.0f/bpm);
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 4:
				blueButton.GetComponent<AudioSource> ().Play ();
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.blue;
				yield return new WaitForSeconds (60.0f/bpm);
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;
			}
		}

		isPatternShowing = false;
	}
}
