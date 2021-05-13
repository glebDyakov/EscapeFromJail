using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KillZek : MonoBehaviour {
	//public Text textCoins;
	//GameObject textCoins = GameObject.FindGameObjectWithTag("TextCoinsTag");
	public float healthBarScale;
	public float healthBarScaleUnit;
	public float enemiesLeftBarScale;
	public bool isDie;
	int textCointCount = 0;

	public bool ballDamage = false;
	public bool dinamitDamage = false;

	public float hp = 100f;
	float damage = 20f;
	public GameObject healthBar;
	Animator anima;
	public AudioClip shoot;
	public AudioClip scream;
	public GameObject enemiesLeftBar;
	//public AddCoins addCoins = new AddCoins();
	// Use this for initialization
	/*
	void OnCollisionEnter2D (Collision2D other) {
		//if (other.gameObject.tag == "Bullet") {
		Destroy (this.gameObject, 1f);
		//}
	}
	*/
	void Start(){
		healthBarScale = healthBar.transform.localScale.x;
		healthBarScaleUnit = healthBarScale / 100f;
		enemiesLeftBarScale = enemiesLeftBar.transform.localScale.x;
		anima = GetComponent <Animator>();
	}

	void PreDie (){
		
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
			if (!dinamitDamage || !ballDamage) {
				hp -= 20f;
			} else if(dinamitDamage){
				hp -= 60f;
				dinamitDamage = false;
			} else if(ballDamage){
				hp -= 100f;
				ballDamage = false;
			}

			if(!isDie){
				healthBar.transform.localScale = new Vector2 (healthBarScaleUnit * hp + 3.2f, healthBar.transform.localScale.y);
				
			}
		} else {
			if (!isDie) {
				isDie = true;
				anima.Play("Z_D");
				RedrawBarOfEnemiesLeft.Redraw ();
			}
			//Destroy (this.gameObject, 1f);

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

		if(enemiesLeftBar.transform.localScale.x + 16f >= enemiesLeftBarScale - 16f / 5f && !isDie){
			enemiesLeftBar.transform.localScale = new Vector2 (enemiesLeftBar.transform.localScale.x - 16f / 5f, enemiesLeftBar.transform.localScale.y);
		}
	}

	void OnMouseDown(){
		
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

	void OnTriggerEnter2D (Collider2D other) {
		/*
		if (other.gameObject.name.Contains("dinamit")) {
			dinamitDamage = true;
			//Анимация взрыва динамита
			print ("dinamitMeAttack");
			//hp -= 60f;
			PreDie ();
		} else if(other.gameObject.name.Contains("ball")) {
			ballDamage = true;
			print ("ballMeAttack");
			//hp -= 100f;
			PreDie ();
		} 
		*/

		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
			//hp -= 20f;
			PreDie ();
		} else if (other.gameObject.tag.Contains ("Player") && GetComponent<MoveZek>().rowOfZek == other.GetComponent<ReceiveDamageFromKickZek>().rowOfWatcher) {
			//меняем флаг на то что зек стопорится
			//DANGER GetComponent<MoveZek>().walk=false;
			PreDie ();
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if(other.gameObject.name == "ball" || other.gameObject.name == "ball(Clone)") {
			if (ballDamage) {
				hp -= 1;
				print ("ballMeAttack");
				//Анимация кровотечения
			}
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "dinamit" || other.gameObject.name == "dinamit(Clone)") {
			dinamitDamage = false;
			print ("dinamitMeAttack");

		} else if (other.gameObject.name == "ball" || other.gameObject.name == "ball(Clone)") {
			ballDamage = false;

			print ("ballMeAttack");
		} else if (other.gameObject.tag.Contains ("Player")) {
			//меняем флаг на бег разрешен
			//DANGER GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
		}
	}
	public void Die(){
		Destroy (this.gameObject, 1f);
	}

}
