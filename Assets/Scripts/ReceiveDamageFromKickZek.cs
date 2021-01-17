using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReceiveDamageFromKickZek : MonoBehaviour {
	public GameObject healthBar;
	// Use this for initialization
	void OnCollisionEnter2D (Collision2D other) {
		healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - 0.2f, healthBar.transform.localScale.y);
		if(healthBar.transform.localScale.x <= 0f){
			SceneManager.LoadScene ("Menu");
		}
		print ("Kick");
	}
	void OnTriggerEnter2D (Collider2D other) {
		healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - 0.2f, healthBar.transform.localScale.y);
		if(healthBar.transform.localScale.x <= 0f){
			PlayerPrefs.SetInt("TextCoinsAll", PlayerPrefs.GetInt("TextCoinsAll") + PlayerPrefs.GetInt("TextCoinsInLevel"));
			SceneManager.LoadScene ("Menu");
			print (PlayerPrefs.GetInt("TextCoinsAll"));
		}
		print ("Kick trigger");
	}
	/*
	void OnTriggerStay2D (Collider2D other) {
		//Animation.Play("ZekKick");

		print ("Kick triggerStay");
	}
	*/
}
