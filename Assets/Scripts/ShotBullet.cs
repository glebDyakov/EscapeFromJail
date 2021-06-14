using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotBullet : MonoBehaviour {
	public GameObject changeWeaponButton;
	public Text countOfBulletOfShootgun;
	public GameObject ammoPrefab;
	public GameObject allAmmos;
	public Behaviour setCountOfAmmoInt;
	public Animator anim;// = GetComponent<Animator>();
	public float speed = 20f;
	public AudioClip shoot;
	public GameObject bullet;
	public Vector2 mousePoint;
	public Vector2 currentPoint;
	public float timeElapsed;
	public Vector2 valueToLerp;
	float startTime;
	SetCountOfAmmo ammoInst;
	GameObject bulletInst;
	bool reload=false;
	void Awake(){
		ammoInst = new SetCountOfAmmo ();

	}



	public void OnMouseUp () {


		if (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count >= 1
			
	) {
			anim.gameObject.GetComponent<ReceiveDamageFromKickZek>().reload = false;
			

			// здесь было удаление пули
			Destroy (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets [setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count - 1]);
			setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Remove (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets [setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count - 1]);
			print (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets);


			float posX = Input.mousePosition [0];
			float posY = Input.mousePosition [1];


			
			if(ActionsForButtons.selectedWeapon.Contains("Shootgun") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1){
				PlayerPrefs.SetInt ("CountShootgunAmmo", PlayerPrefs.GetInt ("CountShootgunAmmo") - 1);
				countOfBulletOfShootgun.text = PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
				if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count <= SetCountOfAmmo.countAmmo + 2){
					anim.Play("O_s-1");	
					bulletInst = Instantiate (bullet, new Vector2(-4.8f, -2.5f), Quaternion.identity) as GameObject;

					if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
						AudioSource audioShoot = GetComponent<AudioSource> ();
						audioShoot.clip = shoot;
						audioShoot.Play ();
					}
				}
				
				if(PlayerPrefs.GetInt ("CountShootgunAmmo") == 0){
					ActionsForButtons.selectedWeapon = "Pistol";
					SetCountOfAmmo.countAmmo = PlayerPrefs.GetInt ("CountAmmo");
					anim.Play("O_p-0");
					changeWeaponButton.GetComponent<ActionsForButtons>().selectedWeaponIcon.sprite = changeWeaponButton.GetComponent<ActionsForButtons>().icons[1];
					countOfBulletOfShootgun.text = "∞";
				}
				
			} else if(ActionsForButtons.selectedWeapon.Contains("Pistol")){
				if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count <= SetCountOfAmmo.countAmmo + 3){
					anim.Play("O_p-1");
					bulletInst = Instantiate (bullet, new Vector2(-4.8f, -2.5f), Quaternion.identity) as GameObject;

					if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
						AudioSource audioShoot = GetComponent<AudioSource> ();
						audioShoot.clip = shoot;
						audioShoot.Play ();
					}
				}
			}
			bulletInst.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 600f);
			
			
		}

		if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count == 0){
			if(ActionsForButtons.selectedWeapon.Contains("Shootgun") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1){
				anim.Play ("O_s-2");

			} else if(ActionsForButtons.selectedWeapon.Contains("Pistol")){
				anim.Play ("O_p-2");
			}
			
		}

	}

	public void ShowAmmo(){
		if(ActionsForButtons.selectedWeapon.Contains("Pistol")){
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("O_p-2")){
				int ammo = setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count;
				if(ammo <= SetCountOfAmmo.countAmmo - 1){
					GameObject ammoOne = Instantiate (ammoPrefab, new Vector2(-12f + ammo, 5f), Quaternion.Euler(0f, 0f, 50f));
					ammoOne.transform.parent = allAmmos.transform;
					setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Add (ammoOne);
					
				}

				if(ammo>=SetCountOfAmmo.countAmmo){
					if(ActionsForButtons.selectedWeapon.Contains("Pistol")){
						anim.Play("O_p-2");
					} else if(ActionsForButtons.selectedWeapon.Contains("Shootgun")){
						anim.Play("O_s-2");
					}
				}
			
			}
		} else if(ActionsForButtons.selectedWeapon.Contains("Shootgun") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1){
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("O_s-2")){
				int ammo = setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count;
				if(ammo <= SetCountOfAmmo.countAmmo - 1){
					GameObject ammoOne = Instantiate (ammoPrefab, new Vector2(-12f + ammo, 5f), Quaternion.Euler(0f, 0f, 50f));
					ammoOne.transform.parent = allAmmos.transform;
					setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Add (ammoOne);
					
				}

				if(ammo>=SetCountOfAmmo.countAmmo){
					if(ActionsForButtons.selectedWeapon.Contains("Pistol")){
						anim.Play("O_p-2");
					} else if(ActionsForButtons.selectedWeapon.Contains("Shootgun")){
						anim.Play("O_s-2");
					}
				}
			
			}
		}
	}


	void Update(){
		if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count >= SetCountOfAmmo.countAmmo/* && reload*/){
			

			if(anim && anim.GetCurrentAnimatorStateInfo(0).IsName("O_p-2")){
				anim.Play("O_p-0");
			}
			if(anim && anim.GetCurrentAnimatorStateInfo(0).IsName("O_s-2") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1){
				anim.Play("O_s-0");
			}
		}
		

	}


}
