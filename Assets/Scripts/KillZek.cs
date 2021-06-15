using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KillZek : MonoBehaviour {
	AudioSource audioShoot;
	public Text waveNumber;
	public float healthBarScale;
	public float healthBarScaleUnit;
	public float enemiesLeftBarScale;
	public bool isDie;
	int textCointCount = 0;
	
	public bool ballDamage = false;
	public bool dinamitDamage = false;
	public float fullHP=100;
	public float hp;
	public float damage = 0.1f;
	public GameObject healthBar;
	public Animator anima;
	public AudioClip shoot;
	public AudioClip scream;
	public AudioClip ambulance;
	public GameObject enemiesLeftBar;
	public GameObject EnemyCop;
	public bool isTrap=false;
	public int minWave=1;
	float startHealthBar;

	void Start(){

 		audioShoot = GetComponent<AudioSource> ();

		waveNumber = GameObject.FindGameObjectWithTag("WaveNumber").GetComponent<Text>();
		hp = fullHP;
		healthBar = transform.GetChild (0).GetChild (0).gameObject;
		enemiesLeftBar= transform.GetChild (0).GetChild (0).gameObject;
		healthBarScale = healthBar.transform.localScale.x;
		healthBarScaleUnit = healthBarScale / hp;
		enemiesLeftBarScale = enemiesLeftBar.transform.localScale.x;
		anima = GetComponent <Animator>();
	}

	void Update(){
		if(!EnemyCop && GetComponent<MoveZek>().walk==false && !isTrap){
			GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
			
		}
	}

	public void PreDie (float hpDamage = 20f){
		
		if (hp > 0f) {
			if(hpDamage>0){
				if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
					audioShoot.clip = scream;
					audioShoot.Play();
				}
			}
			if (!dinamitDamage || !ballDamage) {
				hp -= hpDamage;
			} else if(dinamitDamage){
				hp -= 60f;
				dinamitDamage = false;
			} else if(ballDamage){
				hp -= 100f;
				ballDamage = false;
			}

			if(!isDie){
				isTrap = false;
				healthBar.transform.localScale = new Vector2 (healthBarScaleUnit * hp , healthBar.transform.localScale.y);
				if(healthBar.transform.localScale.x >= 0.9174312f){
					hp=fullHP;
					healthBar.transform.localScale = new Vector2 (0.9174312f, healthBar.transform.localScale.y);
				}
			}
		} if(hp <= 0f){
			
			bool allZeksKilled = false;

			if (!isDie) {
				healthBar.transform.localScale = new Vector2 (0, healthBar.transform.localScale.y);
				isDie = true;
				print ("ВСЕГО"+SpawnZek.countOfZeks);
				anima.Play("Z_D");
				gameObject.GetComponent <Collider2D>().enabled=false;
				if(!gameObject.name.Contains("оборотень(Clone)")){
					allZeksKilled = RedrawBarOfEnemiesLeft.Redraw ();	
				}
				bool haveWallet = false;
				int randomHaveWallet = Random.Range(1, 101);
				haveWallet = randomHaveWallet > 50 ? true : false;
				if (haveWallet) {
					GameObject.Find ("All Coins").GetComponent<SpawnCoin> ().RulkaCoin (gameObject);
				}
			}
			
			if(allZeksKilled){
				if(SpawnZek.Wave==0){
					//История
				SceneManager.LoadScene ("Menu");
				} else {
					//выживание
					GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale = new Vector2(31f, GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale.y);
					SpawnZek.Wave++;
					audioShoot.clip = ambulance;
					audioShoot.Play();
					waveNumber.text = "Wave: " + SpawnZek.Wave.ToString();
					SpawnZek.countOfZeks = 5 * SpawnZek.Wave;
					transform.parent.GetComponent<SpawnZek>().Spawn();
					print("SpawnZek.countOfZeks: " + SpawnZek.countOfZeks.ToString());
				}
			}

		}
		textCointCount += 50;
	}

	

	public void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
			transform.GetChild (0).gameObject.SetActive (true);

			//Invoke ("ActiveHealth", 2);

			if (ActionsForButtons.selectedWeapon.Contains ("Pistol")) {
				PreDie ();
			} else if (ActionsForButtons.selectedWeapon.Contains ("Shootgun")) {
				print ("ForceOfShootgun: " + PlayerPrefs.GetFloat ("ForceOfShootgun").ToString ());
				if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.30f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 0.39f) {
					if (gameObject.name.Contains ("Зек")) {
						PreDie (30f);
					} else if (gameObject.name.Contains ("BigGuy")) {
						PreDie (15f);
					} else if (gameObject.name.Contains ("вор")) {
						PreDie (30f);
					} else if (gameObject.name.Contains ("Лидер")) {
						PreDie (25f);
					} else if (gameObject.name.Contains ("оборотень")) {
						PreDie (10f);
					}
				} else if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.60f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 0.69f) {
					if (gameObject.name.Contains ("Зек")) {
						PreDie (40f);
					} else if (gameObject.name.Contains ("BigGuy")) {
						PreDie (25f);
					} else if (gameObject.name.Contains ("вор")) {
						PreDie (40f);
					} else if (gameObject.name.Contains ("Лидер")) {
						PreDie (35f);
					} else if (gameObject.name.Contains ("оборотень")) {
						PreDie (20f);
					}
				} else if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.90f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 1.50f) {
					if (gameObject.name.Contains ("Зек")) {
						PreDie (50f);
					} else if (gameObject.name.Contains ("BigGuy")) {
						PreDie (35f);
					} else if (gameObject.name.Contains ("вор")) {
						PreDie (50f);
					} else if (gameObject.name.Contains ("Лидер")) {
						PreDie (45f);
					} else if (gameObject.name.Contains ("оборотень")) {
						PreDie (30f);
					}
				}
			}
		} else if (other.gameObject.tag.Contains ("Player") && GetComponent<MoveZek> ().rowOfZek == other.gameObject.GetComponent<ReceiveDamageFromKickZek> ().rowOfWatcher) {
			//меняем флаг на то что зек стопорится
			EnemyCop = other.gameObject;


			anima.Play("Z_A");
			GetComponent<MoveZek> ().walk = false;
		}
		else if (other.name.Contains ("naruchniki")) {
			GetComponent<MoveZek> ().walk = false;
			Destroy (other.gameObject);
			isTrap = true;
			//Анимация стана
			anima.Play("Z_P");
			int delay = 0;
			if(PlayerPrefs.GetFloat ("ForceOfNaruchniki") >= 0.2f && PlayerPrefs.GetFloat("ForceOfNaruchniki") <= 0.3f){
				delay = 3;
			} else if(PlayerPrefs.GetFloat("ForceOfNaruchniki") >= 0.4f && PlayerPrefs.GetFloat("ForceOfNaruchniki") <= 0.5f){
				delay = 5;	
			} else if(PlayerPrefs.GetFloat("ForceOfNaruchniki") >= 0.6f && PlayerPrefs.GetFloat("ForceOfNaruchniki") <= 0.7f){
				delay = 7;
			} else if(PlayerPrefs.GetFloat("ForceOfNaruchniki") >= 0.8f && PlayerPrefs.GetFloat("ForceOfNaruchniki") <= 0.9f){
				delay = 9;
			} else if(PlayerPrefs.GetFloat("ForceOfNaruchniki") >= 1f){
				delay = 11;
			}
			Invoke ("NeverGiveUpZeck", delay);
		}
		else if (other.name.Contains ("svist")) {
			GetComponent<MoveZek> ().walk = false;
			Destroy (other.gameObject);
			isTrap = true;
			//Анимация стана
			anima.Play("Z_P");
			int delay = 0;
			if(PlayerPrefs.GetFloat ("ForceOfSvist") >= 0.2f && PlayerPrefs.GetFloat("ForceOfSvist") <= 0.3f){
				if (gameObject.name.Contains ("Зек")) {
					delay = 3 * 2;
				} else if (gameObject.name.Contains ("BigGuy")) {
					delay = 3 * 1;
				} else if (gameObject.name.Contains ("вор")) {
					delay = 3 * 1;
				} else if (gameObject.name.Contains ("Лидер")) {
					delay = 3 * 3;
				} else if (gameObject.name.Contains ("оборотень")) {
					delay = 3 * 2;
				}
			} else if(PlayerPrefs.GetFloat("ForceOfSvist") >= 0.4f && PlayerPrefs.GetFloat("ForceOfSvist") <= 0.5f){
				if (gameObject.name.Contains ("Зек")) {
					delay = 5 * 2;
				} else if (gameObject.name.Contains ("BigGuy")) {
					delay = 5 * 1;
				} else if (gameObject.name.Contains ("вор")) {
					delay = 5 * 1;
				} else if (gameObject.name.Contains ("Лидер")) {
					delay = 5 * 3;
				} else if (gameObject.name.Contains ("оборотень")) {
					delay = 5 * 2;
				}
			} else if(PlayerPrefs.GetFloat("ForceOfSvist") >= 0.6f && PlayerPrefs.GetFloat("ForceOfSvist") <= 0.7f){
				if (gameObject.name.Contains ("Зек")) {
					delay = 7 * 2;
				} else if (gameObject.name.Contains ("BigGuy")) {
					delay = 7 * 1;
				} else if (gameObject.name.Contains ("вор")) {
					delay = 7 * 1;
				} else if (gameObject.name.Contains ("Лидер")) {
					delay = 7 * 3;
				} else if (gameObject.name.Contains ("оборотень")) {
					delay = 7 * 2;
				}
			} else if(PlayerPrefs.GetFloat("ForceOfSvist") >= 0.8f && PlayerPrefs.GetFloat("ForceOfSvist") <= 0.9f){
				if (gameObject.name.Contains ("Зек")) {
					delay = 9 * 2;
				} else if (gameObject.name.Contains ("BigGuy")) {
					delay = 9 * 1;
				} else if (gameObject.name.Contains ("вор")) {
					delay = 9 * 1;
				} else if (gameObject.name.Contains ("Лидер")) {
					delay = 9 * 3;
				} else if (gameObject.name.Contains ("оборотень")) {
					delay = 9 * 2;
				}
			} else if(PlayerPrefs.GetFloat("ForceOfSvist") >= 1f){
				if (gameObject.name.Contains ("Зек")) {
					delay = 11 * 2;
				} else if (gameObject.name.Contains ("BigGuy")) {
					delay = 11 * 1;
				} else if (gameObject.name.Contains ("вор")) {
					delay = 11 * 1;
				} else if (gameObject.name.Contains ("Лидер")) {
					delay = 11 * 3;
				} else if (gameObject.name.Contains ("оборотень")) {
					delay = 11 * 2;
				}
			}
			Invoke ("NeverGiveUpZeck", delay);
		}
		if(other.gameObject.tag=="zek" && gameObject.GetComponent<MoveZek> ().rowOfZek == other.gameObject.GetComponent<MoveZek> ().rowOfZek  && other.gameObject.transform.localPosition.x > transform.localPosition.x && GetComponent<SpriteRenderer>().sortingOrder==other.GetComponent<SpriteRenderer>().sortingOrder){
			print("SORT");
			GetComponent<SpriteRenderer>().sortingOrder+=1;
		}
	}

	 void OnTriggerStay2D (Collider2D other) {
		if(other.gameObject.name == "ball" || other.gameObject.name == "ball(Clone)") {
			if (ballDamage) {
				hp -= 1;
				print ("ballMeAttack");
				//Анимация кровотечения
			}
		}else if(other.gameObject.name.Contains("HEAL") && other.transform.parent.GetComponent<KillZek>().minWave==4
			&& minWave!=4 ){
				gameObject.GetComponent<KillZek> ().PreDie (-1);
			}
	}

	void ActiveHealth(){
		transform.GetChild (0).gameObject.SetActive (false);
	}
	public void Die(){
		Destroy (this.gameObject, 1f);
	}

	public  void ZeckAttack(){
		if(EnemyCop){
		ReceiveDamageFromKickZek cop=EnemyCop.GetComponent<ReceiveDamageFromKickZek>();
			if(PlayerPrefs.GetInt("ShieldEnabled") == 1){

				print ("ShieldEnabled: " +PlayerPrefs.GetInt("ShieldEnabled").ToString());
				print ("ForceOfShield: " + PlayerPrefs.GetFloat("ForceOfShield").ToString());

				if(PlayerPrefs.GetFloat("ForceOfShield") >= 0.2f && PlayerPrefs.GetFloat("ForceOfShield") <= 0.3f){
					if (gameObject.name.Contains ("Зек")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 3f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("BigGuy")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 2f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("вор")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 5f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("Лидер")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 3f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("оборотень")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 3f, cop.healthBar.transform.localScale.y);
					}

					cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());	

				} else if(PlayerPrefs.GetFloat("ForceOfShield") >= 0.4f && PlayerPrefs.GetFloat("ForceOfShield") <= 0.5f){
					if (gameObject.name.Contains ("Зек")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 5f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("BigGuy")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 3f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("вор")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 7f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("Лидер")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 5f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("оборотень")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 5f, cop.healthBar.transform.localScale.y);
					}
					cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());	
				} else if(PlayerPrefs.GetFloat("ForceOfShield") >= 0.6f && PlayerPrefs.GetFloat("ForceOfShield") <= 0.7f){
					if (gameObject.name.Contains ("Зек")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 7f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("BigGuy")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 5f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("вор")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 9f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("Лидер")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 7f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("оборотень")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 7f, cop.healthBar.transform.localScale.y);
					}
					cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());	
				} else if(PlayerPrefs.GetFloat("ForceOfShield") >= 0.8f && PlayerPrefs.GetFloat("ForceOfShield") <= 0.9f){
					if (gameObject.name.Contains ("Зек")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 9f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("BigGuy")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 11f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("вор")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 11f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("Лидер")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 9f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("оборотень")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 9f, cop.healthBar.transform.localScale.y);
					}
					cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());	
				} else if(PlayerPrefs.GetFloat("ForceOfShield") >= 1f){
					if (gameObject.name.Contains ("Зек")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 11f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("BigGuy")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 10f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("вор")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 13f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("Лидер")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 11f, cop.healthBar.transform.localScale.y);
					} else if (gameObject.name.Contains ("оборотень")) {
						cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage / 11f, cop.healthBar.transform.localScale.y);
					}
					cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());	
				}

			} else if(PlayerPrefs.GetInt("ShieldEnabled") == 0){
				cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - damage, cop.healthBar.transform.localScale.y);
				cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
			}

		}
	}
	void NeverGiveUpZeck(){
		GetComponent<MoveZek>().walk=true;
		anima.Play("Z_R");
		isTrap = false;
	}
}
