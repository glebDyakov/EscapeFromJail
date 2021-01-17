using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour {

	public Image btnChangeSound;
	void Start(){
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			btnChangeSound.GetComponent<Image>().color = new Color32(255,255,255,255);
		} else {
			
			btnChangeSound.GetComponent<Image>().color = new Color32(100,100,100,255);
		}
	}
	void OnMouseDown () {
		if(PlayerPrefs.GetString ("AudioOn") == "Yes"){
			PlayerPrefs.SetString ("AudioOn", "No");
			btnChangeSound.GetComponent<Image>().color = new Color32(100,100,100,255);
		}else if(PlayerPrefs.GetString ("AudioOn") == "No"){
			PlayerPrefs.SetString("AudioOn", "Yes");
			btnChangeSound.GetComponent<Image>().color = new Color32(255,255,255,255);
		}
		/*
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			btnChangeSound.GetComponent<Image>().color = new Color32(100,100,100,255);
		} else {
			btnChangeSound.GetComponent<Image>().color = new Color32(255,255,255,255);
		}
		*/
		print (PlayerPrefs.GetString ("AudioOn"));

	}
}
