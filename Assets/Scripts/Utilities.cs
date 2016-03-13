using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {
	public static void ChangeScene(int scene, float seconds) {
		// StartCoroutine(Wait (seconds));
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene);

	}

	public static void PlayClip(AudioClip clip, int volume) {
		AudioSource.PlayClipAtPoint (clip, new Vector3 (0.0f, 0.0f, 0.0f), volume);

	}

	public IEnumerator Wait(float seconds) {
		yield return new WaitForSeconds (seconds);
	}
}
