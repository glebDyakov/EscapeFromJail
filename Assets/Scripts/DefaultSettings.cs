using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettings : MonoBehaviour {

	void Start () {
		if (!PlayerPrefs.HasKey ("AudioOn")) {
			PlayerPrefs.SetString ("AudioOn", "Yes");
		}
		if (!PlayerPrefs.HasKey ("lastAvailableLevel")) {
			PlayerPrefs.SetInt ("lastAvailableLevel", 1);
		}
		if (!PlayerPrefs.HasKey ("TextCoinsAll")) {
			PlayerPrefs.SetInt ("TextCoinsAll", 0);
		}

		PlayerPrefs.SetInt ("TextCoinsInLevel", 0);		

		print (PlayerPrefs.GetString ("AudioOn"));
	}
}
