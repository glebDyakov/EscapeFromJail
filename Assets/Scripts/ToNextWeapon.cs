using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextWeapon : MonoBehaviour {

	public GameObject uziSelectButton;
	public GameObject uziExpandButton;
	public GameObject ammosButton;

	public int cursorOfItems = 1;

	public GameObject progressBar;
	public string currentTabName;
	public UnityEngine.UI.Text countOfThings;
	public List<GameObject> listOfWeapons;
	public int cursor = 1;

	void Start(){
		//PlayerPrefs.SetInt ("CountAmmo", 1);
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

		if (!currentTabName.Contains ("Other")) {
			progressBar.SetActive (true);
			uziExpandButton.SetActive (true);
			ammosButton.SetActive (true);
		}

		if(currentTabName.Contains("Weapon")){
			
			//ButtonsClick.currentItemInShop = "uzi";
			cursorOfItems++;
			if(cursorOfItems == 2){
				ButtonsClick.currentItemInShop = "stick";
				countOfThings.text = "1";
				progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = 1f / 2f * PlayerPrefs.GetInt ("CountStickAmmo");


				/*
				if(PlayerPrefs.GetInt ("CountStickAmmo") >= 2){
					uziSelectButton.GetComponent<Collider2D> ().enabled = false;
					uziExpandButton.GetComponent<Collider2D> ().enabled = false;
				}
				*/



				if (PlayerPrefs.GetInt ("CountStickAmmo") >= 2) {
					uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Улучшено макс.";
				} else {
					uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandStick + ButtonsClick.priceForExpandStick * PlayerPrefs.GetInt ("CountStickAmmo")).ToString ();
				}

				ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: 1";

			} else if(cursorOfItems == 3){
				ButtonsClick.currentItemInShop = "shootgun";
				countOfThings.text = PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
				progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfShootgun");
				/*
				if(PlayerPrefs.GetInt ("CountShootgunAmmo") >= 3){
					uziSelectButton.GetComponent<Collider2D> ().enabled = false;
					uziExpandButton.GetComponent<Collider2D> ().enabled = false;
				}
				*/

				if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.90f) {
					uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Улучшено макс.";
				} else {
					uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandShootgun + ButtonsClick.priceForExpandShootgun * PlayerPrefs.GetFloat ("ForceOfShootgun")).ToString ();
				}

				ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
			}

		} else if(currentTabName.Contains("Trap")){
			countOfThings.text = PlayerPrefs.GetInt ("CountSvist").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfSvist");
			ButtonsClick.currentItemInShop = "svist";

			if (PlayerPrefs.GetFloat ("ForceOfSvist") >= 1.0f) {
				uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Улучшено макс.";
			} else {
				uziExpandButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Expand: " + Mathf.CeilToInt(ButtonsClick.priceForExpandSvist + ButtonsClick.priceForExpandSvist * PlayerPrefs.GetFloat ("ForceOfSvist")).ToString();
			}

			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountSvist").ToString();

		} else if(currentTabName.Contains("Defence")){
			countOfThings.text = "";
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfDirty");
			ButtonsClick.currentItemInShop = "dirty";

			if (PlayerPrefs.GetFloat ("ForceOfDirty") >= 1.0f) {
				uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Улучшено макс.";
			} else {
				uziExpandButton.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = "Expand: " + Mathf.CeilToInt (ButtonsClick.priceForExpandDirty + ButtonsClick.priceForExpandDirty * PlayerPrefs.GetFloat ("ForceOfDirty")).ToString ();
			}

			ammosButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Боеприпасы: 1";

		} else if(currentTabName.Contains("Other")){
			progressBar.SetActive (false);
			countOfThings.text = "";
			uziExpandButton.SetActive (false);
			ammosButton.SetActive (false);
		}

		if (!currentTabName.Contains ("Weapon") || (currentTabName.Contains ("Weapon") && PlayerPrefs.GetInt ("CountAmmo") > 5)) {
			uziExpandButton.GetComponent<Collider2D> ().enabled = true;
		}
	}
}
