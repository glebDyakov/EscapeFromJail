using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCoins : MonoBehaviour {
	[SerializeField]
	public Text textCoinsText;
	// Use this for initialization

	public void Add(int textCoins){
		textCoinsText.text = "Coins: " + textCoins.ToString();
	}
}
