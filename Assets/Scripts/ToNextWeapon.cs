using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextWeapon : MonoBehaviour {
	public List<GameObject> listOfWeapons;
	public int cursor = 1;
	void Start(){
		cursor = 1;
		listOfWeapons [0].SetActive (true);
	}
	void OnMouseUpAsButton () {
		/*
		foreach(weapon : listOfWeapons){
			weapon.SetActive(false);
		}
		*/
		for(int weapon = 0; weapon < listOfWeapons.Count; weapon++){
			listOfWeapons[weapon].SetActive(false);
		}

		listOfWeapons [cursor].SetActive (true);
		if (cursor + 1 < listOfWeapons.Count) {
			cursor++;
		}
	}
}
