using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	public GameObject yellowButton;
	public GameObject greenButton;
	public GameObject redButton;
	public GameObject blueButton;
	public GameObject pointGUI;
	public AudioClip pointSound;
	public AudioClip errorSound;

	private int playerPoints = 0;
	private List<int> pattern = new List<int>();
	private bool isPlayerTurn = false;
	private bool isPatternShowing = false;
	private int actual = 0;

	void Update () {
		if (!isPlayerTurn) {
			pattern.Add (Random.Range (1, 5));
			StartCoroutine(ShowPattern());
			isPlayerTurn = true;

		}

		pointGUI.GetComponent<UnityEngine.UI.Text> ().text = "Points: " + playerPoints;
	}

	private IEnumerator ShowPattern() {
		isPatternShowing = true;

		yield return new WaitForSeconds (1.5f);

		for (int i = 0; i < pattern.Count; i++) {
			switch (pattern[i]) {
			case 1:
				yellowButton.GetComponent<AudioSource> ().Play ();
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.yellow;
				yield return new WaitForSeconds (0.5f);
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 2:
				greenButton.GetComponent<AudioSource> ().Play ();
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
				yield return new WaitForSeconds (0.5f);
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 3:
				redButton.GetComponent<AudioSource> ().Play ();
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
				yield return new WaitForSeconds (0.5f);
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			case 4:
				blueButton.GetComponent<AudioSource> ().Play ();
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.blue;
				yield return new WaitForSeconds (0.5f);
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				break;

			}
		}

		isPatternShowing = false;
	}

	public void pressButton(GameObject button) {
		if (!isPlayerTurn || isPatternShowing)
			return;

		if (pattern [actual] != button.GetComponent<Button> ().id) {
			Utilities.PlayClip (errorSound, 100);
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
		Utilities.PlayClip (pointSound, 100);
		playerPoints++;

	}
}
