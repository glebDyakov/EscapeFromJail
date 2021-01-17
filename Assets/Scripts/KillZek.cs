using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AddCoins))]
public class KillZek : MonoBehaviour {
	//public Text textCoins;
	//GameObject textCoins = GameObject.FindGameObjectWithTag("TextCoinsTag");
	int textCointCount = 0;
	float hp = 100f;
	float damage = 20f;
	public GameObject healthBar;
	public AudioClip shoot;
	public AudioClip scream;
	//public AddCoins addCoins = new AddCoins();
	// Use this for initialization
	/*
	void OnCollisionEnter2D (Collision2D other) {
		//if (other.gameObject.tag == "Bullet") {
		Destroy (this.gameObject, 1f);
		//}
	}
	*/
	void OnMouseDown(){
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			AudioSource audioShoot = GetComponent<AudioSource> ();
			audioShoot.clip = shoot;
			audioShoot.Play ();
		}
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			AudioSource audioShoot = GetComponent<AudioSource> ();
			audioShoot.clip = scream;
			audioShoot.Play ();
		}
		if (hp > 0f) {
			hp -= 20f;
			healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x / 100f * hp, healthBar.transform.localScale.y);
		} else {
			Destroy (this.gameObject, 0.2f);
			/*
			bool allZeksKilled = RedrawBarOfEnemiesLeft.Redraw ();
			if(allZeksKilled){
				SceneManager.LoadScene ("Menu");
			}
			*/
		}

		print("уничтожен из за нажатия мыши");
		//Destroy (this.gameObject, 0.2f);
		textCointCount += 50;
		//AddCoins.Add (textCointCount);
		//gameObject.SendMessage("Add", textCointCount);
		//addCoins.Add(textCointCount);
		//textCoins.text = "Coins: " + textCointCount.ToString();
	}
	/*
	void OnTriggerEnter2D (Collider2D other) {
		//if (other.gameObject.tag == "Bullet") {
			print("уничтожен");
			Destroy (this.gameObject, 1f);
		//}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		print("уничтожен");
		Destroy (this.gameObject, 1f);
	}
	*/


}
