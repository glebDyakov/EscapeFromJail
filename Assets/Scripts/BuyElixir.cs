using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyElixir : MonoBehaviour {
	
	public Text textCountOfElixirs;
	public int elixirPrice;
	public GameObject elixirBuyWindow;
	public Text coins;

	void OnMouseDown () {
		if (PlayerPrefs.GetInt ("TextCoinsAll") >= elixirPrice) {
			PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - elixirPrice);
			PlayerPrefs.SetInt ("ElixirsCount", PlayerPrefs.GetInt ("ElixirsCount") + 1);
			print ("вы купили эликсир");



		} else {
			GetComponent<AudioSource> ().Play ();
			print ("не хватает денег на покупку эликсира");
		}

		Invoke("UpdateTextCountOfElixirs", 1f);
	}
	void UpdateTextCountOfElixirs(){
		textCountOfElixirs.text = PlayerPrefs.GetInt ("ElixirsCount").ToString ();
		coins.text = PlayerPrefs.GetInt ("TextCoinsAll").ToString ();
		elixirBuyWindow.SetActive (false);
	}
}
