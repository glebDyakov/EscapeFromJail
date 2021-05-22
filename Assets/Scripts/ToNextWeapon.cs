using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextWeapon : MonoBehaviour {

	public GameObject progressBar;
	public string currentTabName;
	public UnityEngine.UI.Text countOfThings;
	public List<GameObject> listOfWeapons;
	public int cursor = 1;

	void Start(){
		PlayerPrefs.SetInt ("CountAmmo", 1);
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
		}

		if(currentTabName.Contains("Weapon")){
			ButtonsClick.currentItemInShop = "uzi";
			countOfThings.text = PlayerPrefs.GetInt ("CountAmmo").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = 1f / 10f * PlayerPrefs.GetInt ("CountAmmo");
		} else if(currentTabName.Contains("Trap")){
			countOfThings.text = PlayerPrefs.GetInt ("CountSvist").ToString();
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfSvist");
			ButtonsClick.currentItemInShop = "svist";
		} else if(currentTabName.Contains("Defence")){
			countOfThings.text = "";
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerPrefs.GetFloat ("ForceOfDirty");
			ButtonsClick.currentItemInShop = "dirty";
		} else if(currentTabName.Contains("Other")){
			progressBar.SetActive (false);
			countOfThings.text = "";
		}

	}
}
