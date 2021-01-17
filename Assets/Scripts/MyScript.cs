using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RedrawBarOfEnemiesLeft))]
[RequireComponent(typeof(SetCountOfAmmo))]
public class MyScript : MonoBehaviour {
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
		print (PlayerPrefs.GetInt ("CountAmmo"));
		//zekprefab.transform.parent = allZeks.transform;
		//Destroy (.);

		/*
		*	перересовываем панель количества оставшихся противников
		*/
		//RedrawBarOfEnemiesLeft.Redraw();

		//маленькая
		//GameObject bulletInst = Instantiate (bullet, new Vector2(-1.1f, 0.46f), Quaternion.identity) as GameObject;
		//большая
		bulletInst = Instantiate (bullet, new Vector2(-2.22f, -0.39f), Quaternion.identity) as GameObject;
		//bulletInst = Instantiate (bullet, new Vector2(18, 32f), Quaternion.identity) as GameObject;

		//bulletInst.transform.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), 20f * Time.deltaTime);
	
		//bulletInst.transform.Translate(Vector3.forward * Time.deltaTime);
		print (Input.mousePosition);
		print (Input.mousePosition [0]);

		print (Input.mousePosition [1]);
	
		print (Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
	void Update(){
		if(bulletInst){
			bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition)[0], Camera.main.ScreenToWorldPoint(Input.mousePosition)[1]), speed * Time.deltaTime);
		//bulletInst.transform.position=Vector2.MoveTowards(new Vector2(bulletInst.transform.position.x, bulletInst.transform.position.y), new Vector2(Input.mousePosition[0], Input.mousePosition[1]), speed * Time.deltaTime);
			if(bulletInst.transform.position==Input.mousePosition){
				Destroy (bulletInst.gameObject, 1f);
			}
		}

		}

	void OnMouseDown () {
		//GameObject bullet = Instantiate (GameObject.FindGameObjectWithTag("Bullet").gameObject, new Vector2(0f, 0f), Quaternion.identity) as GameObject;
		//print ("b");
	}

	void Start(){
		//print ("c");
	}
}
