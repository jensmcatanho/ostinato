﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	public GameObject yellowButton;
	public GameObject greenButton;
	public GameObject redButton;
	public GameObject blueButton;
	public GameObject pointGUI;

	private int playerPoints = 0;
	private List<int> pattern = new List<int>();
	private bool isPlayerTurn = false;
	private int actual = 0;

	void Start () {
		
	}

	void Update () {
		if (!isPlayerTurn) {
			pattern.Add (Random.Range (1, 4));
			StartCoroutine(ShowPattern());
			isPlayerTurn = !isPlayerTurn;

		}

		pointGUI.GetComponent<UnityEngine.UI.Text> ().text = "Points: " + playerPoints;
	}

	private IEnumerator ShowPattern() {
		yield return new WaitForSeconds (1);

		for (int i = 0; i < pattern.Count; i++) {
			switch (pattern[i]) {
			case 1:
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.yellow;
				yield return new WaitForSeconds (0.5f);
				yellowButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				yield return new WaitForSeconds (0.5f);
				break;

			case 2:
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
				yield return new WaitForSeconds (0.5f);
				greenButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				yield return new WaitForSeconds (0.5f);
				break;

			case 3:
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
				yield return new WaitForSeconds (0.5f);
				redButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				yield return new WaitForSeconds (1);
				break;

			case 4:
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.blue;
				yield return new WaitForSeconds (0.5f);
				blueButton.GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				yield return new WaitForSeconds (0.5f);
				break;

			}
		}
	}

	public void YButton() {
		if (!isPlayerTurn)
			return;

		if (pattern [actual] != 1)
			return;

		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			playerPoints++;
			
		} else {
			actual++;

		}
	}

	public void GButton() {
		if (!isPlayerTurn)
			return;

		if (pattern [actual] != 2)
			return;

		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			playerPoints++;

		} else {
			actual++;

		}
	
	}

	public void RButton() {
		if (!isPlayerTurn)
			return;

		if (pattern [actual] != 3)
			return;

		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			playerPoints++;

		} else {
			actual++;

		}
	
	}

	public void BButton() {
		if (!isPlayerTurn)
			return;

		if (pattern [actual] != 4)
			return;

		if (actual == pattern.Count - 1) {
			actual = 0;
			isPlayerTurn = !isPlayerTurn;
			playerPoints++;

		} else {
			actual++;

		}
	}
}