using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oboroten : KillZek {


	void CreateZeck(){
		GameObject randZeck= transform.parent.GetComponent<SpawnZek>().RandomZeck();
		if(randZeck.name.Contains("Оборотень")){
			randZeck= transform.parent.GetComponent<SpawnZek>().RandomZeck(true);
		}
		GameObject zekprefab=Instantiate (randZeck, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		zekprefab.transform.parent = transform.parent;
		int row= gameObject.GetComponent<MoveZek> ().rowOfZek;
		zekprefab.GetComponent<MoveZek> ().rowOfZek=row;
		string layerRow="";
		switch(row){
		case 1:
			layerRow = "RowOne";
			break;
		case 2:
			layerRow = "RowTwo";
			break;
		case 3:
			layerRow = "RowThree";
			break;
		}
		zekprefab.GetComponent<SpriteRenderer> ().sortingLayerName = layerRow;
		zekprefab.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = layerRow;
		zekprefab.transform.GetChild (0).GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = layerRow;
	}

	public void OnTriggerEnter2D (Collider2D other) {
		

		if (other.gameObject.tag == "Bullet" ) {

			Destroy (other.gameObject);
		
			transform.GetChild (0).gameObject.SetActive (true);
			//DANGER Invoke ("ActiveHealth", 2);
			if (ActionsForButtons.selectedWeapon.Contains ("Pistol")) {
				PreDie ();
			} else if (ActionsForButtons.selectedWeapon.Contains ("Shootgun")) {
				print ("ForceOfShootgun: " + PlayerPrefs.GetFloat ("ForceOfShootgun").ToString ());
				if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.30f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 0.39f) {
					PreDie (30f);	
				} else if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.60f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 0.69f) {
					PreDie (40f);	
				} else if (PlayerPrefs.GetFloat ("ForceOfShootgun") >= 0.90f && PlayerPrefs.GetFloat ("ForceOfShootgun") <= 1.50f) {
					PreDie (50f);
				}
			}
		} else if (other.gameObject.tag.Contains ("Player") && GetComponent<MoveZek> ().rowOfZek == other.GetComponent<ReceiveDamageFromKickZek> ().rowOfWatcher) {
			//меняем флаг на то что зек стопорится
			EnemyCop = other.gameObject;

			anima.Play("Z_D");
			GetComponent<MoveZek> ().walk = false;

		}else if (other.name.Contains ("naruchniki")) {
			GetComponent<MoveZek> ().walk = false;
			Destroy (other);
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
			Destroy (other);
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
	} 

}
