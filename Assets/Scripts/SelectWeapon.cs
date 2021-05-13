using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour {
	public string weaponName;
	// Use this for initialization
	void OnMouseUpAsButton(){
		
		PlayerPrefs.SetString ("SelectedWeapon", weaponName);
		print (PlayerPrefs.GetString ("SelectedWeapon"));

	}
}
