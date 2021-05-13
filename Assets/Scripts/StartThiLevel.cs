using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartThiLevel : MonoBehaviour {
	public string levelName;
	public bool youCan;
	public GameObject windowOfLevelUnavailable;
	void OnMouseDown () {
		if (youCan) {
			SceneManager.LoadScene (levelName);
		} else {
			windowOfLevelUnavailable.SetActive (true);
		}
	}
}
