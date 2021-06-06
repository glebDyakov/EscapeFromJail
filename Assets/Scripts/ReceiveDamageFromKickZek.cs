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
	public GameObject attackZek;
	public bool reload=true;
	public GameObject bullet;
	// Use this for initialization
	void Start(){
		healthBarScaleUnit = healthBar.transform.localScale.x / 100f;
		healthBarScale = healthBar.transform.localScale.x;
		animat = gameObject.GetComponent<Animator>();
		if (bot) {
			animat.Play("O_dub-0");
		}
	}

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Contains("zek")) {
			attackZek = other.gameObject;
			//анимация боли от удара зека
			if(healthBar.transform.localScale.x >= 0f){
				if (rowOfWatcher == 1 && other.GetComponent<MoveZek> ().rowOfZek == 1) {
					//бот атакует
					animat.Play ("O_dub-1");
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 3f, healthBar.transform.localScale.y);
				} else if (rowOfWatcher == 3 && other.GetComponent<MoveZek> ().rowOfZek == 3) {
					//бот атакует
					animat.Play ("O_dub-1");
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				} else if(rowOfWatcher == 2 && other.GetComponent<MoveZek> ().rowOfZek == 2) {
				//охраник тратит жизни
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				}
			}


			if (!bot && healthBar.transform.localScale.x <= 0f) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel"));
				//умерает охранник
				animat.Play ("O_D");
				healthBar.SetActive (false);
				repairLifeBar.SetActive (true);
				print (PlayerPrefs.GetInt ("TextCoinsAll"));
			} else if (bot && healthBar.transform.localScale.x <= 0f) {
				animat.Play ("O_D");
				healthBar.SetActive (false);
			}
			print ("Kick trigger");
		}
	}
	//функция атаки
	public void СopAttack () {
		
		if (attackZek) {
			print ("СopAttack");
			//анимация боли от удара зека
			if (healthBar.transform.localScale.x >= 0f) {
				float damageFromStick = PlayerPrefs.GetInt ("CountStickAmmo") <= 1 ? 40f : PlayerPrefs.GetInt ("CountStickAmmo") >= 2 ? 80f : 40f;
				if (rowOfWatcher == 1 && attackZek.GetComponent<MoveZek> ().rowOfZek == 1) {
					attackZek.GetComponent<KillZek> ().PreDie (damageFromStick);
					attackZek.transform.GetChild(0).gameObject.SetActive(true);
					//Invoke("ActiveHealth",2);
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 3f, healthBar.transform.localScale.y);
				} else if (rowOfWatcher == 3 && attackZek.GetComponent<MoveZek> ().rowOfZek == 3) {
					attackZek.GetComponent<KillZek> ().PreDie (damageFromStick);
					attackZek.transform.GetChild(0).gameObject.SetActive(true);
					//Invoke("ActiveHealth",2);
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				} else if (rowOfWatcher == 2 && attackZek.GetComponent<MoveZek> ().rowOfZek == 2) {
					attackZek.GetComponent<KillZek> ().PreDie (damageFromStick);
					attackZek.transform.GetChild(0).gameObject.SetActive(true);
					//Invoke("ActiveHealth",2);
					//healthBar.transform.localScale = new Vector2 (healthBar.transform.localScale.x - healthBarScale / 5f, healthBar.transform.localScale.y);
				}	
			}
		}
	}

	void ActiveHealth(){
		if (attackZek) {
			attackZek.transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	public void ChangeAnimation () {
		print ("ChangeAnimation");
		if (attackZek) {
			animat.Play ("O_dub-1");
			if (healthBar.transform.localScale.x >= 0f) {
				if (rowOfWatcher == 1 && attackZek.GetComponent<MoveZek> ().rowOfZek == 1) {
					print ("atackZek");
					animat.Play ("O_dub-1");
				}
			}else if (healthBar.transform.localScale.x >= 0f) {
				if (rowOfWatcher == 3 && attackZek.GetComponent<MoveZek> ().rowOfZek == 3) {
					animat.Play ("O_dub-1");
				}
			}
		}
	}
	void DestroyCop(){
		Destroy (healthBar.transform.parent.gameObject,2);
		Destroy(gameObject,2);
		attackZek.GetComponent<MoveZek>().walk=true;
		attackZek.GetComponent<Animator>().Play("Z_R");
	}

	void RoloadPistol(){
		reload = true;
	}
	public void ShowAmmo(){
		bullet.GetComponent<ShotBullet> ().ShowAmmo();
	}
}
