using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	public GameObject area;
	public GameObject progressBar;
	public GameObject healthBarOfWatcher;
	public GameObject allZeks;
	public List<GameObject> watchers;
	public GameObject repairLifeBar;
	public Text expandText;
	public string sceneName;

	void OnApplicationQuit () {
		string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
        PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
        Debug.Log(lastTimestampPlay);
	}
}
