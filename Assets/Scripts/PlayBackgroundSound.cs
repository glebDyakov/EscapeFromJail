using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundSound : MonoBehaviour {

	void Start () {
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			GetComponent<AudioSource> ().Play();
		}
	}
}
