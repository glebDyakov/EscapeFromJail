using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHelp : MonoBehaviour {
	public GameObject help;
	public string actionHelp;
	// Use this for initialization
	void OnMouseDown() {
		if (actionHelp == "open") {
			help.SetActive (true);
		} else if (actionHelp == "close") {
			help.SetActive (false);
		}
		print ("Помощь");
	}
}
