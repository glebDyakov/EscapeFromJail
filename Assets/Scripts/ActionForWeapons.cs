using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionForWeapons : MonoBehaviour {

	public UnityEngine.UI.Image uziImage;
	public UnityEngine.UI.Text ammos;
	public UnityEngine.UI.Text expandText;
	public string action;
	public GameObject progressBar;

	public void Start(){
		ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo").ToString();


		if (PlayerPrefs.GetInt ("CountAmmo") >= 5) {
			expandText.text = "Улучшено макс.";
		} else {
			expandText.text = "Expand: " + Mathf.CeilToInt(ButtonsClick.priceForExpandPistol + ButtonsClick.priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo")).ToString();
		}

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

		if (PlayerPrefs.GetInt ("CountAmmo") < 5) {
			uziImage.color = new Color32 (0, 0, 0, 255);
		}

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
