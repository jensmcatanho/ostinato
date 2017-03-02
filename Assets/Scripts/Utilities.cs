using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {
	public static void ChangeScene(int scene, float seconds) {
		// StartCoroutine(Wait (seconds));
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene);

	}

	public IEnumerator Wait(float seconds) {
		yield return new WaitForSeconds (seconds);
	}
}
