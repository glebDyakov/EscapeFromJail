using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class RepairLife : MonoBehaviour {

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
			SceneManager.LoadScene ("Menu");
		} else if(!repair){
			CancelInvoke ("DigitLess");
		}
	}
}
