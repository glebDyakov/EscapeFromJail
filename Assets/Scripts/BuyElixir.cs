using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyElixir : MonoBehaviour {
	public Text textCountOfElixirs;
	public int elixirPrice;
	public GameObject elixirBuyWindow;

	void OnMouseDown () {
		if (PlayerPrefs.GetInt ("TextCoinsAll") >= elixirPrice) {
			PlayerPrefs.SetInt ("ElixirsCount", PlayerPrefs.GetInt ("ElixirsCount") + 1);
			print ("вы купили эликсир");
			Invoke("UpdateTextCountOfElixirs", 1f);
			elixirBuyWindow.SetActive (false);

		} else {
			print ("не хватает денег на покупку эликсира");
		}


	}
	void updateTextCountOfElixirs(){
		textCountOfElixirs.text = PlayerPrefs.GetInt ("ElixirsCount").ToString ();
	}
}
