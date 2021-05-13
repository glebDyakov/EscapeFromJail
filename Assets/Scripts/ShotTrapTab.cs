using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrapTab : MonoBehaviour {
	public List<GameObject> listOfHides;
	public List<GameObject> listOfShows;
	void OnMouseUpAsButton () {
		print ("ловушки");
		foreach(GameObject itemOfHide in listOfHides){
			itemOfHide.SetActive (false);
		}
		foreach(GameObject itemOfShow in listOfShows){
			itemOfShow.SetActive (true);
		}

	}
}
