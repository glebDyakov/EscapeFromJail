using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReceiveDamageFromKickZek : MonoBehaviour {

	public int rowOfWatcher;
	public float healthBarScaleUnit;
	public float healthBarScale;
	Animator animat;
	public GameObject healthBar;
	public GameObject repairLifeBar;
	public bool bot=false;
	// Use this for initialization
	void Start(){
		healthBarScaleUnit = healthBar.transform.localScale.x / 100f;
		healthBarScale = healthBar.transform.localScale.x;
		animat = gameObject.GetComponent<Animator>();
		if (bot) {
			animat.Play("O_dub-0");
		}
	}
	/*void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag != "Player"){
			animat.Play("Z_A");
			healthBar.transform.localScale = new Vector2(healthBar.transform.localScale.x - 0.2f, healthBar.transform.localScale.y);
			if(healthBar.transform.localScale.x <= 0f){
				//repairLifeBar.SetActive (true);
				//SceneManager.LoadScene ("Menu");

			}
			print ("Kick");
		}
	}*/
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Contains("zek")) {
			//анимация боли от удара зека
			//animat.Play("O_D");
			if(healthBar.transform.localScale.x >= 0f){
				if (rowOfWatcher == 1 && other.GetComponent<MoveZek> ().rowOfZek == 1) {
					//бот атакует
					animat.Play ("O_dub-1");
					healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 3f, healthBar.transform.localScale.y);
				} else if (rowOfWatcher == 3 && other.GetComponent<MoveZek> ().rowOfZek == 3) {
					//бот атакует
					animat.Play ("O_dub-1");
					healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				} else if(rowOfWatcher == 2 && other.GetComponent<MoveZek> ().rowOfZek == 2) {
				//охраник тратит жизни
					healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				}
			}

			//healthBar.transform.localScale.x - 0.2f
			if (!bot && healthBar.transform.localScale.x <= 0f) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel"));
				//умерает охранник
				animat.Play ("O_D");
				repairLifeBar.SetActive (true);
				//SceneManager.LoadScene ("Menu");
				print (PlayerPrefs.GetInt ("TextCoinsAll"));
			} else if (bot && healthBar.transform.localScale.x <= 0f) {
				animat.Play ("O_D");
				//other.gameObject.GetComponent<Animator>().Play ("Z_R");
			}
			print ("Kick trigger");
		}
	}
	/*
	void OnTriggerStay2D (Collider2D other) {
		//Animation.Play("ZekKick");

		print ("Kick triggerStay");
	}
	*/
	void DestroyCop(){
		Destroy (healthBar, 2f);
		Destroy(gameObject, 2f);
	}
}
