using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHelp : MonoBehaviour {

	public GameObject help;
	public string actionHelp;
	public List<GameObject> zeks;
	public int cursorOfZeks = 0;
	public GameObject nextButton;

	public void ShowHelpOfZek(){
		if(cursorOfZeks < zeks.Count - 1){
			cursorOfZeks++;
			foreach(var zek in zeks){
				zek.SetActive (false);
			}
			zeks [cursorOfZeks].SetActive (true);
			if (cursorOfZeks >= zeks.Count - 1) {
				nextButton.SetActive (false);
			}
		}
	}

	void OnMouseDown() {
		if (actionHelp == "open") {
			help.SetActive (true);
			actionHelp = "close";
		} else if (actionHelp == "close") {
			help.SetActive (false);
		} else if (actionHelp == "next") {
			ShowHelpOfZek ();
		}
		print ("Помощь");
	}
}
