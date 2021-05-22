using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotBullet : MonoBehaviour {
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
		if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count == 0){
			anim.Play ("O_p-2");
			//DANGER Invoke ("ShowAmmo", 5f);
		}
		if (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count >= 1
			//&& anim.gameObject.GetComponent<ReceiveDamageFromKickZek>().reload
	) {
			anim.gameObject.GetComponent<ReceiveDamageFromKickZek>().reload = false;
			//ammoInst.bullets[ammoInst.bullets.Count - 1].GetComponent<Renderer>().enabled = false;


			//setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets[setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count - 1].SetActive(false);

			// здесь было удаление пули
			Destroy (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets [setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count - 1]);
			setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Remove (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets [setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets.Count - 1]);
			print (setCountOfAmmoInt.GetComponent<SetCountOfAmmo> ().bullets);

			//SetCountOfAmmo.HideAmmo ();

			if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
				AudioSource audioShoot = GetComponent<AudioSource> ();
				audioShoot.clip = shoot;
				audioShoot.Play ();
				//ammoInst.HideAmmo ();
				/*
			SetCountOfAmmo a = new SetCountOfAmmo();
			a.HideAmmo ();
			*/
			}
			//ammoInst.ShowAmmo ();
			//ammoInst.HideAmmo ();

			PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt ("CountAmmo") - 1);
			//print (PlayerPrefs.GetInt ("CountAmmo"));
			//zekprefab.transform.parent = allZeks.transform;
			//Destroy (.);

			/*
		*	перересовываем панель количества оставшихся противников
		*/
			//RedrawBarOfEnemiesLeft.Redraw();

			//маленькая
			//GameObject bulletInst = Instantiate (bullet, new Vector2(-1.1f, 0.46f), Quaternion.identity) as GameObject;
			//большая

			//bulletInst = Instantiate (bullet, new Vector2(-2.22f, -0.39f), Quaternion.identity) as GameObject;

			/*
		Vector3 point = new Vector3();
		Event   currentEvent = Event.current;
		Vector2 mousePos = new Vector2();

		*/
			// Get the mouse position from Event.
			// Note that the y position from Event is inverted.

			/*
		float posX = currentEvent.mousePosition.x;
		float posY = currentEvent.mousePosition.y;
		*/

			float posX = Input.mousePosition [0];
			float posY = Input.mousePosition [1];


			//point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
			//float xPos = Camera.main.ScreenToWorldPoint(5f,5f,1f);

			anim.Play("O_p-1");

			//bulletInst = Instantiate (bullet, new Vector2 (-1.76749f, -2.102378f), Quaternion.identity) as GameObject;

			//bulletInst = Instantiate (bullet, Camera.main.ScreenToWorldPoint(new Vector2 (posX,posY)), Quaternion.identity) as GameObject;

			if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count <= 2){
				bulletInst = Instantiate (bullet, new Vector2(-8f, -2.5f), Quaternion.identity) as GameObject;
			}


			//bulletInst.GetComponent<Rigidbody2D>().MovePosition ();
			//Destroy (bulletInst, 5f);

			//bulletInst = Instantiate (bullet, new Vector2(18, 32f), Quaternion.identity) as GameObject;

			//bulletInst.transform.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), 20f * Time.deltaTime);

			//bulletInst.transform.Translate(Vector3.forward * Time.deltaTime);
			/*
		print (Input.mousePosition);

		print (Input.mousePosition [0]);

		print (Input.mousePosition [1]);

		print (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		*/
			//DANGER Invoke ("ShowAmmo", 5f);
			//anim.Play("O_p-2");
		}
	}

	public void ShowAmmo(){
		//reload = true;
		//anim.Play("O_p-2");
		/*
		for (int ammo = setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count; ammo < 2; ammo++) {
			GameObject ammoOne = Instantiate (ammoPrefab, new Vector2(-12f + ammo, 5f), Quaternion.Euler(0f, 0f, 50f));
			ammoOne.transform.parent = allAmmos.transform;
			setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Add (ammoOne);
			PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt("CountAmmo" + 1));
			print ("CountAmmo " + PlayerPrefs.GetInt("CountAmmo"));
		}
		*/
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("O_p-2")){
		int ammo = setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count;
		if(ammo <= 2){
			GameObject ammoOne = Instantiate (ammoPrefab, new Vector2(-12f + ammo, 5f), Quaternion.Euler(0f, 0f, 50f));
			ammoOne.transform.parent = allAmmos.transform;
			setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Add (ammoOne);
			PlayerPrefs.SetInt ("CountAmmo", PlayerPrefs.GetInt("CountAmmo" + 1));
			//Invoke ("ShowAmmo", 5f);
			//anim.Play("O_p-2");
		}

		if(ammo>=2){
			anim.Play("O_p-0");
		}
		
		//print (allAmmos.transform.GetChild(allAmmos.transform.childCount - 1));
		}
	}


	void Update(){
		if(setCountOfAmmoInt.GetComponent<SetCountOfAmmo>().bullets.Count>=2/* && reload*/){
			//reload = false;
			if(anim && anim.GetCurrentAnimatorStateInfo(0).IsName("O_p-2")){
			anim.Play("O_p-0");
			}
		}
		/*if(bulletInst){
			bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition)[0], Camera.main.ScreenToWorldPoint(Input.mousePosition)[1]), speed * Time.deltaTime);
			//bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), speed * Time.deltaTime);
			if(bulletInst.transform.position==Input.mousePosition){
				Destroy (bulletInst.gameObject, 1f);
			}
		}*/

	}


}
