using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GrabeSpider : MonoBehaviour {

	public Text GUICountOfCoins;
	public string numberLevel;
	Rigidbody2D rb;
	Animator anim;

	void Start(){
		anim=GetComponent <Animator>();
		rb = GetComponent <Rigidbody2D>();
		GUICountOfCoins = GameObject.FindGameObjectWithTag("TextCoinsTag").GetComponent<Text>();
	}

	void OnMouseDown () {
		//уничтожение паука и получение монет
		//int coinsInLevel = PlayerPrefs.GetInt("TextCoinsInLevel") + 1;

		//GUICountOfCoins.text = "Coins: " + coinsInLevel.ToString();
		//PlayerPrefs.SetInt ("TextCoinsInLevel", coinsInLevel);

		GrabCoins.w += 1;
		GUICountOfCoins.text = "Coins: " + GrabCoins.w.ToString();
		PlayerPrefs.SetInt ("TextCoinsInLevel", GrabCoins.w);
		anim.enabled = false;
		rb.isKinematic = false;
		rb.AddForce (transform.up * 1000f);
		Destroy (gameObject,2);


	}
}
