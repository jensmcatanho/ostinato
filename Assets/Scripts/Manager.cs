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

	void Start () {
		

	}

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

	public void YButton() {
		if (!isPlayerTurn || isPatternShowing)
			return;

		if (pattern [actual] != 1) {
			AudioSource.PlayClipAtPoint (errorSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			StartCoroutine(ChangeScene(2));
			return;
		}

		yellowButton.GetComponent<AudioSource> ().Play ();
		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			AudioSource.PlayClipAtPoint (pointSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			playerPoints++;
			
		} else {
			actual++;

		}
	}

	public void GButton() {
		if (!isPlayerTurn || isPatternShowing)
			return;

		if (pattern [actual] != 2) {
			AudioSource.PlayClipAtPoint (errorSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			StartCoroutine(ChangeScene(2));
			return;
		}

		greenButton.GetComponent<AudioSource> ().Play ();
		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			AudioSource.PlayClipAtPoint (pointSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			playerPoints++;

		} else {
			actual++;

		}
	
	}

	public void RButton() {
		if (!isPlayerTurn || isPatternShowing)
			return;

		if (pattern [actual] != 3) {
			AudioSource.PlayClipAtPoint (errorSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			StartCoroutine(ChangeScene(2));
			return;
		}

		redButton.GetComponent<AudioSource> ().Play ();
		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			AudioSource.PlayClipAtPoint (pointSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			playerPoints++;

		} else {
			actual++;

		}
	
	}

	public void BButton() {
		if (!isPlayerTurn || isPatternShowing)
			return;

		if (pattern [actual] != 4) {
			AudioSource.PlayClipAtPoint (errorSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			StartCoroutine(ChangeScene(2));
			return;
		}

		blueButton.GetComponent<AudioSource> ().Play ();
		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			AudioSource.PlayClipAtPoint (pointSound, new Vector3 (0.0f, 0.0f, 0.0f), 100);
			playerPoints++;

		} else {
			actual++;

		}
	}

	private IEnumerator ChangeScene(int scene) {
		yield return new WaitForSeconds (1);
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene);
	}
}
