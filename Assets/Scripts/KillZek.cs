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
	public Animator anima;
	public AudioClip shoot;
	public AudioClip scream;
	public GameObject enemiesLeftBar;
	public GameObject EnemyCop;

	void Start(){
		healthBar = transform.GetChild (0).GetChild (0).gameObject;
		enemiesLeftBar= transform.GetChild (0).GetChild (0).gameObject;
		healthBarScale = healthBar.transform.localScale.x;
		healthBarScaleUnit = healthBarScale / 100f;
		enemiesLeftBarScale = enemiesLeftBar.transform.localScale.x;
		anima = GetComponent <Animator>();
	}

	void Update(){
		if(!EnemyCop && GetComponent<MoveZek>().walk==false){
			GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
		}
	}

	public void PreDie (){
		
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			AudioSource audioShoot = GetComponent<AudioSource> ();
			audioShoot.clip = shoot;
			audioShoot.Play();
		}
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			AudioSource audioShoot = GetComponent<AudioSource> ();
			audioShoot.clip = scream;
			audioShoot.Play();
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
			
			bool allZeksKilled = false;

			if (!isDie) {
				isDie = true;
				anima.Play("Z_D");
				allZeksKilled = RedrawBarOfEnemiesLeft.Redraw ();
				GameObject.Find("All Coins").GetComponent<SpawnCoin>().RulkaCoin(gameObject);
			}
			//Destroy (this.gameObject, 1f);


			//bool allZeksKilled = RedrawBarOfEnemiesLeft.Redraw ();
			if(allZeksKilled){
				if(transform.parent.GetComponent<SpawnZek>().Wave==0){
				SceneManager.LoadScene ("Menu");
				}else{
					transform.parent.GetComponent<SpawnZek> ().Wave++;
					StartCoroutine (transform.parent.GetComponent<SpawnZek>().Spawn ());
				}
			}

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

	public void OnTriggerEnter2D (Collider2D other/*, bool bita=false*/) {
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

		if (other.gameObject.tag == "Bullet" /*|| bita*/) {
			/*if(!bita){*/
			Destroy (other.gameObject);
			//}
			transform.GetChild(0).gameObject.SetActive(true);
			Invoke("ActiveHealth",2);
			PreDie ();
		} else if (other.gameObject.tag.Contains ("Player") && GetComponent<MoveZek>().rowOfZek == other.GetComponent<ReceiveDamageFromKickZek>().rowOfWatcher) {
			//меняем флаг на то что зек стопорится
			EnemyCop=other.gameObject;
			anima.Play("Z_A");
			GetComponent<MoveZek>().walk=false;
			//PreDie ();
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
			GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
		}
	}

	void ActiveHealth(){
		transform.GetChild (0).gameObject.SetActive (false);
	}
	public void Die(){
		Destroy (this.gameObject, 1f);
	}

	public void ZeckAttack(){
		if(EnemyCop){
		ReceiveDamageFromKickZek cop=EnemyCop.GetComponent<ReceiveDamageFromKickZek>();
			cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
		//EnemyCop.GetComponent<Animator>().Play("O_dub-1");
			//cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - cop.healthBarScale / 3f, cop.healthBar.transform.localScale.y);
		}
		/*else if(!EnemyCop){
			GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
		}*/
	}
}
