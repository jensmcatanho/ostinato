using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameplaySystem : MonoBehaviour {
	// References to other systems.
	public GameObject audioSystem; 
	public GameObject guiSystem;

	public int playerPoints = 0;
	public List<int> pattern = new List<int>();
	private bool isPlayerTurn = false;
	private int actual = 0;

	public int bpm = 60;

	void Update() {
		if (!isPlayerTurn) {
			pattern.Add(Random.Range (1, 5));
			StartCoroutine(guiSystem.GetComponent<GUISystem> ().ShowPattern());
			isPlayerTurn = true;

		}
	}

	public void pressButton(GameObject button) {
		if (!isPlayerTurn || guiSystem.GetComponent<GUISystem> ().isPatternShowing)
			return;

		if (pattern [actual] != button.GetComponent<Button> ().id) {
			audioSystem.GetComponent<AudioSystem> ().ErrorSound (100);
			PlayerPrefs.SetInt ("currentScore", playerPoints);
			Utilities.ChangeScene (2, 1.2f);
			return;
		}

		button.GetComponent<AudioSource> ().Play ();

		if (actual != pattern.Count - 1) {
			actual++;
			return;
		}

		actual = 0;
		isPlayerTurn = false;
		audioSystem.GetComponent<AudioSystem> ().PointSound (100);
		playerPoints++;

	}
}
