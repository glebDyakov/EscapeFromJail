using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsClick : MonoBehaviour {

	public int priceForExpandPistol = 50;
	public int priceForExpandUzi = 100;
	public int priceForExpandNaruchniki = 5;
	public int priceForExpandSvist = 10;
	public int priceForExpandShield = 15;
	public int priceForExpandDirty = 20;
	public List<AudioClip> clips;

	public GameState gameState;
	public Animator animat;
	public Text ammosText;

	public static string currentItemInShop = "pistol";

	public void Start(){
		gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
	}

	public void BuyAmmos (){
		
	}

	public void ExpandWeapon(){
		gameState = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
		if (currentItemInShop.Contains ("pistol") || currentItemInShop.Contains ("uzi")) {
			if (PlayerPrefs.GetString ("SelectedWeapon").Contains ("Pistol")) {
				if (PlayerPrefs.GetInt ("CountAmmo") < 5 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandPistol) {
					PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandPistol);
					gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
					PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt ("CountAmmo") + 1);
					ammosText.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo");
					GetComponent<AudioSource> ().clip = clips [0];
					GetComponent<AudioSource> ().Play ();
					
				} else {
					GetComponent<AudioSource> ().clip = clips [1];
					GetComponent<AudioSource> ().Play ();
				}
			} else if (PlayerPrefs.GetString ("SelectedWeapon").Contains ("Uzi")) {
				if (PlayerPrefs.GetInt ("CountAmmo") < 10 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandUzi) {
					PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandUzi);
					gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 10f;
					PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt ("CountAmmo") + 1);
					ammosText.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountAmmo");
					GetComponent<AudioSource> ().clip = clips [0];
					GetComponent<AudioSource> ().Play ();
				} else {
					GetComponent<AudioSource> ().clip = clips [1];
					GetComponent<AudioSource> ().Play ();
				}
			}
		} else if (currentItemInShop.Contains ("naruchniki")) {
			if (PlayerPrefs.GetInt ("ForceOfNaruchniki") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandNaruchniki) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandNaruchniki);
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfNaruchniki", PlayerPrefs.GetFloat ("ForceOfNaruchniki") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();
			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		} else if (currentItemInShop.Contains ("svist")) {
			if (PlayerPrefs.GetInt ("ForceOfSvist") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandSvist) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandSvist);
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfSvist", PlayerPrefs.GetFloat ("ForceOfSvist") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();
			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		} else if (currentItemInShop.Contains ("shield")) {
			if (PlayerPrefs.GetInt ("ForceOfShield") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandShield) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandShield);
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfShield", PlayerPrefs.GetFloat ("ForceOfShield") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();
			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		} else if (currentItemInShop.Contains ("dirty")) {
			if (PlayerPrefs.GetInt ("ForceOfDirty") < 1 && PlayerPrefs.GetInt ("TextCoinsAll") > priceForExpandDirty) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - priceForExpandDirty);
				gameState.progressBar.GetComponent<Image> ().fillAmount += 1 / 5f;
				PlayerPrefs.SetFloat ("ForceOfDirty", PlayerPrefs.GetFloat ("ForceOfDirty") + 0.2f);
				GetComponent<AudioSource> ().clip = clips [0];
				GetComponent<AudioSource> ().Play ();
			} else {
				GetComponent<AudioSource> ().clip = clips [1];
				GetComponent<AudioSource> ().Play ();
			}
		}
		print ("TextCoinsAll: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString());
		print ("CountAmmo: " + PlayerPrefs.GetInt ("CountAmmo").ToString());
	}

	public void Dubinka(){
		animat.Play("O_dub-1");
	}

	public void LoadMenu(){
		
		SceneManager.LoadScene ("Menu");
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
