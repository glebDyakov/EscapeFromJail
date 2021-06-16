using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class RepairLife : MonoBehaviour {

	public GameObject backgroundLevel;
	public GameObject doubleCoinsButton;
	public GameObject windowLoose;
	public Button repairButton;
	public Text digit;
	public bool repair = true;
	public ButtonsClick buttonsClick;
	
	/*
	public UnityEvent respawnButtonDelegate;
	*/

	void OnEnable () {
		InvokeRepeating ("DigitLess", 2f, 2f);	
		repairButton.onClick.AddListener(buttonsClick.RespawnCop);
	}
	

	void  DigitLess() {
		digit.text = (int.Parse(digit.text) - 1).ToString();
		if (int.Parse (digit.text) <= 0 && repair) {
			CancelInvoke ("DigitLess");
			if(PlayerPrefs.GetInt ("DoubleCoinsEnabled") == 1){
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel") * 2);
			} else if(PlayerPrefs.GetInt ("DoubleCoinsEnabled") == 0){
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel"));
			}
			SetCountOfAmmo.countAmmo = 0;
			gameObject.SetActive(false);
			windowLoose.SetActive(true);
			Destroy(backgroundLevel.GetComponent<BoxCollider2D>());
			
			for(int child = 0; child <= buttonsClick.gameState.allZeks.transform.childCount - 1; child++){
				buttonsClick.gameState.allZeks.transform.GetChild(child).gameObject.GetComponent<MoveZek>().walk = false;
				Destroy(buttonsClick.gameState.allZeks.transform.GetChild(child).gameObject);
			}
			if(PlayerPrefs.GetInt ("DoubleCoinsEnabled") == 1){
				windowLoose.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>().text = (PlayerPrefs.GetInt ("TextCoinsInLevel") * 2).ToString();
			} else if(PlayerPrefs.GetInt ("DoubleCoinsEnabled") == 0){
				if(PlayerPrefs.GetInt ("TextCoinsInLevel") > 0){
					doubleCoinsButton.SetActive(true);
				}
				windowLoose.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt ("TextCoinsInLevel").ToString();
			}
			PlayerPrefs.SetInt ("TextCoinsInLevel", 0);
			//SceneManager.LoadScene ("Menu");
		} else if(!repair){
			CancelInvoke ("DigitLess");
		}
	}
}
