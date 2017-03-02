using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {
	public AudioClip pointSound;
	public AudioClip errorSound;

	void Start () {
		
	}

	void Update () {
		
	}

	public void PlayClip(AudioClip clip, int volume) {
		AudioSource.PlayClipAtPoint (clip, new Vector3 (0.0f, 0.0f, 0.0f), volume);
	}

	public void ErrorSound(int volume) {
		PlayClip (errorSound, volume);
	}

	public void PointSound(int volume) {
		PlayClip (pointSound, volume);
	}
}
