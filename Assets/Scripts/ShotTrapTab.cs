using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrapTab : MonoBehaviour {

	public GameState gameState;

	public List<GameObject> listOfNextButtons;

	public GameObject selectButton;
	public GameObject expandButton;
	public GameObject ammosButton;

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

		foreach(var nextButton in listOfNextButtons){
			nextButton.GetComponent<ToNextWeapon> ().cursor = 1;
			nextButton.GetComponent<ToNextWeapon> ().cursorOfItems = 1;
		}

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
			ammosButton.SetActive (true);
			expandButton.SetActive (true);
		}

		if (tabHeader.Contains ("Weapons")){
			ButtonsClick.currentItemInShop = "pistol";
			countOfThings.text = PlayerPrefs.GetInt ("CountAmmo").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = 1 - 1 / PlayerPrefs.GetInt ("CountAmmo");
			if (PlayerPrefs.GetInt ("CountAmmo") >= 5) {
				gameState.expandText.text = "Улучшено макс.";
			} else {
				gameState.expandText.text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandPistol + ButtonsClick.priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo")).ToString ();
			}
			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo").ToString();
		} else if (tabHeader.Contains ("Traps")){
			ButtonsClick.currentItemInShop = "naruchniki";
			countOfThings.text = PlayerPrefs.GetInt ("CountNaruchniki").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfNaruchniki");

			if (PlayerPrefs.GetFloat ("ForceOfNaruchniki") >= 1.0f) {
				gameState.expandText.text = "Улучшено макс.";
			} else {
				gameState.expandText.text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandNaruchniki + ButtonsClick.priceForExpandNaruchniki * PlayerPrefs.GetFloat ("ForceOfNaruchniki")).ToString ();
			}
			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountNaruchniki").ToString();
		} else if (tabHeader.Contains ("Deffences")){
			ButtonsClick.currentItemInShop = "shield";
			countOfThings.text = "";
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfShield");
			if (PlayerPrefs.GetFloat ("ForceOfShield") >= 1.0f) {
				gameState.expandText.text = "Улучшено макс.";
			} else {
				gameState.expandText.text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandShield + ButtonsClick.priceForExpandShield * PlayerPrefs.GetFloat ("ForceOfShield")).ToString ();
			}
			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: 1";
		} else if (tabHeader.Contains ("Others")){
			countOfThings.text = PlayerPrefs.GetInt ("ElixirsCount").ToString();
			progressBar.SetActive (false);
			ammosButton.SetActive (false);
			expandButton.SetActive (false);
			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: " + PlayerPrefs.GetInt ("ElixirsCount").ToString();
		}

		selectButton.GetComponent<Collider2D> ().enabled = true;
		expandButton.GetComponent<Collider2D> ().enabled = true;

	}
}
