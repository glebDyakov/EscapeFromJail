using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrapTab : MonoBehaviour {

	public UnityEngine.UI.Text countOfThings;
	public string tabHeader;
	public GameObject selectedWeaponButton;
	public List<GameObject> listOfHides;
	public List<GameObject> listOfShows;
	public GameObject progressBar;
	public UnityEngine.UI.Text coins;

	void Start(){
		countOfThings.text = PlayerPrefs.GetInt ("CountAmmo").ToString();
		coins.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString();
	}

	void OnMouseUpAsButton () {
		print ("ловушки");
		foreach(GameObject itemOfHide in listOfHides){
			itemOfHide.SetActive (false);
		}
		foreach(GameObject itemOfShow in listOfShows){
			itemOfShow.SetActive (true);
		}

		/*
		if (tabHeader.Contains ("Weapons") && !selectedWeaponButton.activeSelf) {
			selectedWeaponButton.SetActive (true);
		} else if(!tabHeader.Contains ("Weapons") && selectedWeaponButton.activeSelf){
			selectedWeaponButton.SetActive (false);
		}
		*/


		if (!tabHeader.Contains ("Others")) {
			progressBar.SetActive (true);
		}

		if (tabHeader.Contains ("Weapons")){
			ButtonsClick.currentItemInShop = "pistol";
			countOfThings.text = PlayerPrefs.GetInt ("CountAmmo").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = 1 / PlayerPrefs.GetInt ("CountAmmo");
		} else if (tabHeader.Contains ("Traps")){
			ButtonsClick.currentItemInShop = "naruchniki";
			countOfThings.text = PlayerPrefs.GetInt ("CountNaruchniki").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfNaruchniki");
		} else if (tabHeader.Contains ("Deffences")){
			ButtonsClick.currentItemInShop = "shield";
			countOfThings.text = "";
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfShield");
		} else if (tabHeader.Contains ("Others")){
			countOfThings.text = PlayerPrefs.GetInt ("ElixirsCount").ToString();
			progressBar.SetActive (false);
		}
	}
}
