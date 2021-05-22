using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionForWeapons : MonoBehaviour {

	public UnityEngine.UI.Text ammos;
	public string action;
	public GameObject progressBar;

	public void Start(){
		ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo").ToString();
		float amount = 1f;
		if (PlayerPrefs.GetString ("SelectedWeapon").Contains("pistol")) {
			amount = 1f / 5f;
		} else if (PlayerPrefs.GetString ("SelectedWeapon").Contains("uzi")) {
			amount = 1f / 10f;
		}
		if(PlayerPrefs.GetInt ("CountAmmo") >= 1){
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = amount * PlayerPrefs.GetInt ("CountAmmo");
		} else if(PlayerPrefs.GetInt ("CountAmmo") <= 0){
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = amount * 1;
		}
		print (PlayerPrefs.GetInt ("CountAmmo").ToString());
	}

	void OnMouseDown () {
		if (action.Contains ("expand")) {
			print ("expand weapon");
			progressBar.GetComponent<ButtonsClick> ().ExpandWeapon ();
		} else if (action.Contains ("buy")) {
			print ("buy ammos");
			progressBar.GetComponent<ButtonsClick> ().BuyAmmos ();
		}
	}

}
