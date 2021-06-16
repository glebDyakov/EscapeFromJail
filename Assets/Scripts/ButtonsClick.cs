using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsClick : MonoBehaviour {

	public static string selectedWeapon = "Pistol";
	public static int priceForExpandPistol = 50;
	public static int priceForExpandStick = 75;
	public static int priceForExpandShootgun = 100;
	public static int priceForExpandUzi = 100;
	public static int priceForExpandNaruchniki = 35;
	public static int priceForExpandSvist = 50;
	public static int priceForExpandShield = 75;
	public static int priceForExpandDirty = 100;
	public List<AudioClip> clips;

	public GameState gameState;
	public Animator animat;

	public Text ammosText;
	public Text expandText;
	public Text coinsText;
	public Text countOfThings;

	public static string currentItemInShop = "pistol";

	public void Start(){
		
		gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
		expandText = gameState.expandText;
	}

	public void BuyAmmos (){
		
	}

	public void ExpandWeapon(){
		gameState = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
		if (currentItemInShop.Contains ("pistol") || currentItemInShop.Contains ("stick") || currentItemInShop.Contains ("shootgun")) {
			if (currentItemInShop.Contains ("pistol")) {
				if (PlayerPrefs.GetInt ("CountAmmo") < 5 && PlayerPrefs.GetInt ("TextCoinsAll") >= Mathf.CeilToInt(priceForExpandPistol + priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo"))) {
					PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandPistol + priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo")));
					expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandPistol + priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo")).ToString();
					gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
					PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt ("CountAmmo") + 1);
					ammosText.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo");
					coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
					GetComponent<AudioSource> ().clip = clips [0];
					GetComponent<AudioSource> ().Play ();
					countOfThings.text = "Coins: " + PlayerPrefs.GetInt ("CountAmmo").ToString();
					/*
					if(PlayerPrefs.GetInt ("CountAmmo") >= 5){
						PlayerPrefs.SetString ("SelectedWeapon", "Uzi");
					}
					*/


					if (PlayerPrefs.GetInt ("CountAmmo") >= 5) {
						expandText.text = "Улучшено макс.";
					}

				} else {
					GetComponent<AudioSource> ().clip = clips [1];
					GetComponent<AudioSource> ().Play ();
				}
			} else if (currentItemInShop.Contains ("stick")) {
				Debug.Break ();
				if (PlayerPrefs.GetInt ("CountStickAmmo") < 2 && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandStick + priceForExpandStick * PlayerPrefs.GetInt ("CountStickAmmo"))) {
					PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandStick + priceForExpandStick * PlayerPrefs.GetInt ("CountStickAmmo")));
					expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandStick + priceForExpandStick * PlayerPrefs.GetInt ("CountStickAmmo")).ToString();
					gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 2f;
					PlayerPrefs.SetInt ("CountStickAmmo", PlayerPrefs.GetInt ("CountStickAmmo") + 1);
					ammosText.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountStickAmmo");
					coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
					GetComponent<AudioSource> ().clip = clips [0];
					GetComponent<AudioSource> ().Play ();

					if (PlayerPrefs.GetInt ("CountStickAmmo") >= 2) {
						expandText.text = "Улучшено макс.";
					}

				} else {
					GetComponent<AudioSource> ().clip = clips [1];
					GetComponent<AudioSource> ().Play ();
				}
			} else if (currentItemInShop.Contains ("shootgun")) {
				if (PlayerPrefs.GetFloat ("ForceOfShootgun") < 1f - 1f / 3f && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandShootgun + priceForExpandShootgun * PlayerPrefs.GetFloat ("ForceOfShootgun"))) {
					PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandShootgun + priceForExpandShootgun * PlayerPrefs.GetFloat ("ForceOfShootgun")));
					expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandShootgun + priceForExpandShootgun * PlayerPrefs.GetFloat ("ForceOfShootgun")).ToString();
					gameState.progressBar.GetComponent<Image> ().fillAmount += 1f / 3f;
					PlayerPrefs.SetFloat ("ForceOfShootgun", PlayerPrefs.GetFloat ("ForceOfShootgun") + 1f / 3f);
					ammosText.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountShootgunAmmo");
					coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
					GetComponent<AudioSource> ().clip = clips [0];
					GetComponent<AudioSource> ().Play ();

					if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.90f) {
						expandText.text = "Улучшено макс.";
					}

				} else {
					GetComponent<AudioSource> ().clip = clips [1];
					GetComponent<AudioSource> ().Play ();
				}
			}
		} else if (currentItemInShop.Contains ("naruchniki")) {
			if (PlayerPrefs.GetFloat ("ForceOfNaruchniki") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandNaruchniki + priceForExpandNaruchniki * PlayerPrefs.GetFloat ("ForceOfNaruchniki"))) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandNaruchniki + priceForExpandNaruchniki * PlayerPrefs.GetFloat ("ForceOfNaruchniki")));
				coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
				expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandNaruchniki + priceForExpandNaruchniki * PlayerPrefs.GetFloat("ForceOfNaruchniki")).ToString();
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfNaruchniki", PlayerPrefs.GetFloat ("ForceOfNaruchniki") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();

				if (PlayerPrefs.GetFloat ("ForceOfNaruchniki") >= 1.0f) {
					expandText.text = "Улучшено макс.";
				}

			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}

		} else if (currentItemInShop.Contains ("svist")) {
			if (PlayerPrefs.GetFloat ("ForceOfSvist") < 1.0f && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandSvist + priceForExpandSvist * PlayerPrefs.GetFloat ("ForceOfSvist"))) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandSvist + priceForExpandSvist * PlayerPrefs.GetFloat ("ForceOfSvist")));
				coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
				expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandSvist + priceForExpandSvist * PlayerPrefs.GetFloat ("ForceOfSvist")).ToString();
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfSvist", PlayerPrefs.GetFloat ("ForceOfSvist") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();

				if (PlayerPrefs.GetFloat ("ForceOfSvist") >= 1.0f) {
					expandText.text = "Улучшено макс.";
				}

			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
			print (Mathf.CeilToInt(priceForExpandNaruchniki + priceForExpandNaruchniki * PlayerPrefs.GetFloat ("ForceOfNaruchniki")));
		} else if (currentItemInShop.Contains ("shield")) {
			if (PlayerPrefs.GetInt ("ForceOfShield") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandShield + priceForExpandShield * PlayerPrefs.GetFloat ("ForceOfShield"))) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandShield + priceForExpandShield * PlayerPrefs.GetFloat ("ForceOfShield")));
				coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
				expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandShield + priceForExpandShield * PlayerPrefs.GetFloat ("ForceOfShield")).ToString();
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfShield", PlayerPrefs.GetFloat ("ForceOfShield") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();

				if (PlayerPrefs.GetFloat ("ForceOfShield") >= 1.0f) {
					expandText.text = "Улучшено макс.";
				}

			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		} else if (currentItemInShop.Contains ("dirty")) {
			if (PlayerPrefs.GetInt ("ForceOfDirty") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > Mathf.CeilToInt(priceForExpandDirty + priceForExpandDirty * PlayerPrefs.GetFloat ("ForceOfDirty"))) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - Mathf.CeilToInt(priceForExpandDirty + priceForExpandDirty * PlayerPrefs.GetFloat ("ForceOfDirty")));
				coinsText.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString();
				expandText.text = "Expand: " + Mathf.CeilToInt(priceForExpandPistol + priceForExpandPistol * PlayerPrefs.GetInt ("CountAmmo")).ToString();
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfDirty", PlayerPrefs.GetFloat ("ForceOfDirty") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();

				if (PlayerPrefs.GetFloat ("ForceOfDirty") >= 1.0f) {
					expandText.text = "Улучшено макс.";
				}

			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		}
		print ("TextCoinsAll: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString());
		print ("CountAmmo: " + PlayerPrefs.GetInt ("CountAmmo").ToString());
	}

	public void ChangeWeapon(){
		if (selectedWeapon.Contains("Shootgun")) {
			selectedWeapon = "Pistol";
			animat.Play("O_p-0");
		} else if (selectedWeapon.Contains("Pistol") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1) {
			selectedWeapon = "Shootgun";
			animat.Play("O_s-0");
			

		}
		print (selectedWeapon);
	}

	public void Dubinka(){
		selectedWeapon = "Dubinka";
		animat.Play("O_dub-1");
	}


	public void Shootgun(){
		selectedWeapon = "Shootgun";
	}

	public void LoadMenu(){
		
		SceneManager.LoadScene ("Menu");
	}

	public void LoadCustomScene(string sceneName){
		if(sceneName.Contains("Shop")){
			SceneManager.LoadScene("Shop");
		} else if(sceneName.Contains("Main")){
			if(PlayerPrefs.GetInt("CountOfChargedBatteries") > 0){
				string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
				PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
				PlayerPrefs.SetInt ("CountOfChargedBatteries", PlayerPrefs.GetInt ("CountOfChargedBatteries") - 1);
				gameState.sceneName = "Main";
				DontDestroyOnLoad(gameState);
				SceneManager.LoadScene("Intermediate");
			} else if(PlayerPrefs.GetInt("CountOfChargedBatteries") < 0){
				GetComponent<AudioSource>().Play();
			}
		} else if(sceneName.Contains("Level1")){
			if(PlayerPrefs.GetInt("CountOfChargedBatteries") > 0){
				PlayerPrefs.SetInt ("CountOfChargedBatteries", PlayerPrefs.GetInt ("CountOfChargedBatteries") - 1);
				string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
        		PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
				gameState.sceneName = "Level1";
				DontDestroyOnLoad(gameState);
				SceneManager.LoadScene("Intermediate");
			
			} else if(PlayerPrefs.GetInt("CountOfChargedBatteries") < 0){
				GetComponent<AudioSource>().Play();
				//string lastTimestampPlay = DateTime.Now.ToString("dd:MM:yyyy|HH:mm:ss");
        		//PlayerPrefs.SetString("LastTimestampPlay", lastTimestampPlay);
			}
		}
	}

	public void RepairLife(){
		
		gameState.repairLifeBar.GetComponent<RepairLife>().repair = false;
		CancelInvoke ();

		gameState.repairLifeBar.transform.localScale = new Vector2(0f, 0f);
		Invoke ("SetDefaultSettings", 10f);

		gameState.healthBarOfWatcher.transform.localScale = new Vector2 (1f, gameState.healthBarOfWatcher.transform.localScale.y);

		for(int child = 0; child <= gameState.allZeks.transform.childCount - 1; child++){
			Destroy(gameState.allZeks.transform.GetChild(child).gameObject);
		}
	}

	public void SetDefaultSettings(){
		gameState.repairLifeBar.GetComponent<RepairLife> ().digit.text = "3";
		gameState.repairLifeBar.GetComponent<RepairLife> ().repair = true;
		gameState.repairLifeBar.transform.localScale = new Vector2(1f, 1f);
		gameState.repairLifeBar.SetActive (false);

	}

	public void PlayVideoForDoubleCoins(){
		//играем видео при нажатии кнопки двойные монеты
		print("играем видео при нажатии кнопки двойные монеты");
		Camera.main.gameObject.GetComponent<MobAdsRewarded>().enabled = true;
	}

	public void RespawnCop(){
		if(PlayerPrefs.GetInt("ElixirsCount") >= 1){
			//увеличить ХП охраника и уничтожать всех зеков
			PlayerPrefs.SetInt("ElixirsCount", PlayerPrefs.GetInt("ElixirsCount") - 1);
			print (PlayerPrefs.GetInt ("ElixirsCount"));
			this.SendMessage("RepairLife");
			//animat.Play("O_P-0");
		} else if(PlayerPrefs.GetInt("ElixirsCount") <= 0){
			GetComponent<AudioSource> ().Play();
		}
	}

}
