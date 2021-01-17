using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
[RequireComponent(typeof(RedrawBarOfEnemiesLeft))]
[RequireComponent(typeof(SetCountOfAmmo))]
*/
public class ShotBullet : MonoBehaviour {
	public float speed = 20f;
	public AudioClip shoot;
	public GameObject bullet;
	GameObject bulletInst;
	void OnMouseUp () {
		//SetCountOfAmmo.HideAmmo ();
		if (PlayerPrefs.GetString ("AudioOn") == "Yes") {
			AudioSource audioShoot = GetComponent<AudioSource> ();
			audioShoot.clip = shoot;
			audioShoot.Play ();
		}

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

		float posX = Input.mousePosition[0] ;
		float posY = Input.mousePosition[1];


		//point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
		//float xPos = Camera.main.ScreenToWorldPoint(5f,5f,1f);
		bulletInst = Instantiate (bullet, Camera.main.ScreenToWorldPoint(new Vector2(posX, posY)), Quaternion.identity) as GameObject;
		Destroy (bulletInst, 0.5f);

		//bulletInst = Instantiate (bullet, new Vector2(18, 32f), Quaternion.identity) as GameObject;

		//bulletInst.transform.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), 20f * Time.deltaTime);

		//bulletInst.transform.Translate(Vector3.forward * Time.deltaTime);
		/*
		print (Input.mousePosition);

		print (Input.mousePosition [0]);

		print (Input.mousePosition [1]);

		print (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		*/
	}
	/*
	void Update(){
		if(bulletInst){
			bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition)[0], Camera.main.ScreenToWorldPoint(Input.mousePosition)[1]), speed * Time.deltaTime);
			//bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), speed * Time.deltaTime);
			if(bulletInst.transform.position==Input.mousePosition){
				Destroy (bulletInst.gameObject, 1f);
			}
		}

	}
*/
}
