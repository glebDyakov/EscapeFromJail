using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAllCoins : MonoBehaviour {
	public Text textCoins;
	// Use this for initialization
	void Start () {
		textCoins.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
