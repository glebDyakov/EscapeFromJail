using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GrabeSpider : MonoBehaviour {
	Text svistCount;
	Text naruchnikiCount;
	Text GUICountOfCoins;
	public string numberLevel;
	Rigidbody2D rb;
	Animator anim;

	void Start(){
		anim=GetComponent <Animator>();
		rb = GetComponent <Rigidbody2D>();
		GUICountOfCoins = GameObject.FindGameObjectWithTag("TextCoinsTag").GetComponent<Text>();
		svistCount = GameObject.Find("SvistAttackText").GetComponent<Text>();
		naruchnikiCount = GameObject.Find("NaruchnikiAttackText").GetComponent<Text>();
	}

	void OnMouseDown () {
		//уничтожение паука и получение монет
		//int coinsInLevel = PlayerPrefs.GetInt("TextCoinsInLevel") + 1;

		//GUICountOfCoins.text = "Coins: " + coinsInLevel.ToString();
		//PlayerPrefs.SetInt ("TextCoinsInLevel", coinsInLevel);

		int randomSubject = Random.Range(1, 3);
		switch(randomSubject){
		case 1:
		GrabCoins.w += 5;
		GUICountOfCoins.text = "Coins: " + GrabCoins.w.ToString();
		PlayerPrefs.SetInt ("TextCoinsInLevel", GrabCoins.w);
		break;
		case 2:
		if(PlayerPrefs.GetInt ("CountSvist") < BuyProduct.maxCount){
		PlayerPrefs.SetInt ("CountSvist", PlayerPrefs.GetInt ("CountSvist") + 1);
		svistCount.text = PlayerPrefs.GetInt("CountSvist").ToString();
		}
		break;
		case 3:
		if(PlayerPrefs.GetInt ("CountNaruchniki") < BuyProduct.maxCount){
		PlayerPrefs.SetInt ("CountNaruchniki", PlayerPrefs.GetInt ("CountNaruchniki") + 1);
		naruchnikiCount.text = PlayerPrefs.GetInt("CountNaruchniki").ToString();
		}
		break;
		}
		
		anim.enabled = false;
		rb.isKinematic = false;
		rb.AddForce (transform.up * 1000f);
		Destroy (gameObject,2);


	}
}
