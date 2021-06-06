using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZek : MonoBehaviour {
	public List<AudioClip> clips;
	public bool walk=true;
	public float destination;
	public int rowOfZek;
	Animator animat;
	public bool flagStop = false;
	public bool appleStop = false;

	public bool naruchnikiStop = false;
	public bool svistStop = false;

	public float speed = 0.2f;
	public bool zeklazier;
	public AnimationClip zekKick;
	public GameObject[] watchers;
	public GameObject gameState;
	//transform.position = new Vector2 ();

	void Start () {
		animat = gameObject.GetComponent<Animator>();
		gameState = GameObject.FindWithTag("GameState");

		int veroyatnostylaziera = Random.Range (0, 100) ;
		zeklazier = veroyatnostylaziera > 10 ? true : false;

		watchers = GameObject.FindGameObjectsWithTag("Player");
	}
	
	void Update () {
		
		if(rowOfZek == 1
			//transform.localPosition.y < -2.71f
		){
			if (gameState.GetComponent<GameState>().watchers [0] == null) {
				//здесь менять анимацию на бег
				//animat.Play("Z_R");
				//убегает за пределы карты
				destination = -8.000000f;
			}
		} else if(rowOfZek == 2
			//transform.localPosition.y == -2.71f
		){
			if (gameState.GetComponent<GameState>().watchers [1] == null) {
				//здесь менять анимацию на бег
				//animat.Play("Z_R");
			}
		} else if(rowOfZek == 3
			//transform.localPosition.y > -2.71f
		){
			if (gameState.GetComponent<GameState>().watchers [2] == null) {
				//здесь менять анимацию на бег
				//animat.Play("Z_R");
				//убегает за пределы карты
				destination = -8.000000f;
			}
		}

		/*
		if (walk && transform.localPosition.x > destination && !flagStop && !appleStop) {
			if(!GetComponent<KillZek>().isDie){
				if(transform.localPosition.x < -1f){
					if(transform.localPosition.y > -2.25f && !zeklazier){
						transform.Translate (Vector2.up * -(Time.deltaTime * speed));
					}else if(transform.localPosition.y < -2.25f && !zeklazier){
						transform.Translate (Vector2.up * (Time.deltaTime * speed));
					}
				}
				transform.Translate (Vector2.right * -(Time.deltaTime * speed));
			}
			//transform.position = new Vector2 ();		
		} 
		*/
		if (walk /*&& !svistStop && !naruchnikiStop*/) {
			if(!GetComponent<KillZek>().isDie){
				if(transform.localPosition.x < -1f){
					if(transform.localPosition.y > -2.25f && !zeklazier){
						transform.Translate (Vector2.up * -(Time.deltaTime * speed));
						gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
						rowOfZek = 2;
						gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
						gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
					}else if(transform.localPosition.y < -2.25f && !zeklazier){
						transform.Translate (Vector2.up * (Time.deltaTime * speed));
						gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
						rowOfZek = 2;
						gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
						gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
					}
				}
				transform.Translate (Vector2.right * -(Time.deltaTime * speed));
			}
			//transform.position = new Vector2 ();		
		}/* else if(!svistStop && !naruchnikiStop){
			
			if (!GetComponent<KillZek> ().isDie) {
				//animat.Play("Z_A");
			}
		}*/
	}

	void OnTriggerEnter2D (Collider2D other) {
		/*
		if (other.gameObject.name == "flag" || other.gameObject.name == "flag(Clone)") {
			flagStop = true;
			//Анимация оглушения зека
			print ("flagMeAttack");
		} else if (other.gameObject.name == "apple" || other.gameObject.name == "apple(Clone)") {
			appleStop = true;
			print ("appleMeAttack");
			//Анимация с наручниками у зека
		}
		*/
		/*if (other.gameObject.name.Contains("svist")) {
			svistStop = true;
			//Анимация оглушения зека
			print ("svistMeAttack");
		} else if (other.gameObject.name.Contains("naruchniki")) {
			naruchnikiStop = true;
			print ("naruchnikiMeAttack");
			//Анимация с наручниками у зека
		}*/  if (other.gameObject.name.Contains("Deadline")) {
			PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel"));
			gameState.GetComponent<GameState>().repairLifeBar.SetActive (true);
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		

		/*if (other.gameObject.name.Contains("naruchniki")) {
			Destroy(other.gameObject.GetComponent<Rigidbody2D> ());
			Destroy (other.gameObject);
			GetComponent<AudioSource>().clip = clips[1];
			GetComponent<AudioSource> ().Play();
			//Invoke ("ResetNaruchnikiStop", 10f);
			print ("naruchnikiMeAttack");
		} else if (other.gameObject.name.Contains("svist")) {
			GetComponent<AudioSource>().clip = clips[0];
			GetComponent<AudioSource> ().Play();
			//Invoke ("ResetSvistStop", 20f);
			print ("svistMeAttack");
		}*/
	}
	void ResetFlagStop(){
		flagStop = false;
	}

	void ResetSvistStop(){
		svistStop = false;
	}

	void ResetNaruchnikiStop(){
		naruchnikiStop = false;
	}

	void OnMouseDown(){
		gameState.GetComponent<GameState>().area.GetComponent<ShotBullet>().OnMouseUp();
	}

}
