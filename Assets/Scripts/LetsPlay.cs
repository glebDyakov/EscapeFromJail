using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsPlay : MonoBehaviour {

	public void OnMouseDown () {
		/*
		логика которая позволяет играть только если есть батарейки
		if(PlayerPrefs.GetInt ("CountOfChargedBatteries") >= 1){
			PlayerPrefs.SetInt ("CountOfChargedBatteries", PlayerPrefs.GetInt ("CountOfChargedBatteries") - 1);
			SceneManager.LoadScene ("SelectLevel");
		} else if(PlayerPrefs.GetInt ("CountOfChargedBatteries") <= 0){
			GetComponent<AudioSource>().Play();
		}
		*/

		SceneManager.LoadScene ("SelectLevel");
		
	}
}
