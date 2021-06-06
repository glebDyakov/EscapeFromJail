//Анимация наручников
//anim.Play("O_nar-0");

//Анимация свистка
//anim.Play("O_svist");
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAttack : MonoBehaviour {

	public Text svistCount;
	public Text naruchnikiCount;

	public Animator anim;
	GameObject trapInst;
	public float strike;
	public float numberOfSlot;
	//int counter = 0;
	public GameObject dinamitInst;
	public GameObject appleInst;
	public GameObject ballInst;
	public GameObject flagInst;

	public GameObject svistInst;
	public GameObject naruchnikiInst;

	public Sprite dinamitSprite;
	public Sprite appleSprite;
	public Sprite ballSprite;
	public Sprite flagSprite;

	public Sprite svistSprite;
	public Sprite naruchnikiSprite;

	public GameObject dinamitInstPrefab;

	Vector2 startPosition;
	public static Vector2 toPosition;

	void OnMouseDown(){
		if (trapInst.name.Contains ("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") > 0) {
			anim.Play ("O_nar-0");
		}
		startPosition = gameObject.transform.position;
	}
	void OnMouseDrag () {
		if((trapInst.name.Contains("svist") && PlayerPrefs.GetInt ("CountSvist") > 0) || (trapInst.name.Contains("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") > 0)){
			

			print ("атака");
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition[0], Input.mousePosition[1], 5f));

			}
	}

	void OnMouseUp () {
		if ((trapInst.name.Contains ("svist") && PlayerPrefs.GetInt ("CountSvist") > 0) || (trapInst.name.Contains ("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") > 0)) {
			toPosition = gameObject.transform.position;
			Invoke ("ResetPosition", 0.5f);
		}
	}
	void ResetPosition(){
		gameObject.transform.position = startPosition;
		if ((trapInst.name.Contains ("svist") && PlayerPrefs.GetInt ("CountSvist") > 0) || (trapInst.name.Contains ("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") > 0)) {
			dinamitInstPrefab = Instantiate (trapInst, new Vector2 (-8.75f, -2.35f), Quaternion.identity);



			if (dinamitInstPrefab.name.Contains ("svist") || dinamitInstPrefab.name.Contains ("naruchniki")) {
				if (dinamitInstPrefab.name.Contains ("svist")) {
					if (PlayerPrefs.GetInt ("CountSvist") > 0) {
						//анимация с яблоком
						anim.Play ("O_svist");
						print ("1CountSvist: " + PlayerPrefs.GetInt ("CountSvist"));
						print ("1CountNaruchniki: " + PlayerPrefs.GetInt ("CountNaruchniki"));
						PlayerPrefs.SetInt ("CountSvist", PlayerPrefs.GetInt ("CountSvist") - 1);
						svistCount.text = PlayerPrefs.GetInt("CountSvist").ToString();

					}
				} else if (dinamitInstPrefab.name.Contains ("naruchniki")) {
					if (PlayerPrefs.GetInt ("CountNaruchniki") > 0) {
						//анимация с мячом

						anim.Play ("O_nar-1");
						Rigidbody2D dinamitInstrb = dinamitInstPrefab.GetComponent<Rigidbody2D> ();
						dinamitInstrb.AddRelativeForce (toPosition * strike, ForceMode2D.Impulse);
						//dinamitInstrb.AddRelativeForce (new Vector2(250, 50f), ForceMode2D.Impulse);
						PlayerPrefs.SetInt ("CountNaruchniki", PlayerPrefs.GetInt ("CountNaruchniki") - 1);

						naruchnikiCount.text = PlayerPrefs.GetInt("CountNaruchniki").ToString();

						Invoke ("DestroyWeapon", 0.5f);
					}
				}
			}
		} else if((trapInst.name.Contains ("svist") && PlayerPrefs.GetInt ("CountSvist") <= 0) || (trapInst.name.Contains ("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") <= 0)){
			
				print ("2CountSvist: " + PlayerPrefs.GetInt ("CountSvist"));
				print ("2CountNaruchniki: " + PlayerPrefs.GetInt ("CountNaruchniki"));
				GetComponent<AudioSource> ().Play ();

		}
	}
	void DestroyWeapon(){
		if (dinamitInstPrefab) {
			Destroy (dinamitInstPrefab, 0.5f);
		}
		}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Start(){
		PlayerPrefs.SetInt ("CountSvist", 5);
		PlayerPrefs.SetInt ("CountNaruchniki", 5);

		/*
		//anim = GetComponent<Animator>();
		PlayerPrefs.SetString ("FirstSlotOfTrap", "ball");
		PlayerPrefs.SetString ("SecondSlotOfTrap", "flag");
		PlayerPrefs.SetString ("ThirdSlotOfTrap", "dinamit");
		PlayerPrefs.SetString ("FourthSlotOfTrap", "apple");
		if (numberOfSlot == 1f) {
			if (PlayerPrefs.GetString ("FirstSlotOfTrap") == "dinamit") {
				trapInst = dinamitInst;
				gameObject.GetComponent<Image>().sprite = dinamitSprite;
			} else if (PlayerPrefs.GetString ("FirstSlotOfTrap") == "ball") {
				trapInst = ballInst;
				gameObject.GetComponent<Image>().sprite = ballSprite;
			} else if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "apple" ){
				trapInst = appleInst;
				gameObject.GetComponent<Image>().sprite = appleSprite;	
			} else if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "flag"){
				trapInst = flagInst;
				gameObject.GetComponent<Image>().sprite = flagSprite;
			}
		} else if (numberOfSlot == 2f) {
			if (PlayerPrefs.GetString ("SecondSlotOfTrap") == "dinamit") {
				trapInst = dinamitInst;
				gameObject.GetComponent<Image>().sprite = dinamitSprite;
			} else if (PlayerPrefs.GetString ("SecondSlotOfTrap") == "ball") {
				trapInst = ballInst;
				gameObject.GetComponent<Image>().sprite = ballSprite;
			} else if(PlayerPrefs.GetString ("SecondSlotOfTrap") == "apple" ){
				trapInst = appleInst;
				gameObject.GetComponent<Image>().sprite = appleSprite;	
			} else if(PlayerPrefs.GetString ("SecondSlotOfTrap") == "flag"){
				trapInst = flagInst;
				gameObject.GetComponent<Image>().sprite = flagSprite;
			}
		} else if (numberOfSlot == 3f) {
			if (PlayerPrefs.GetString ("ThirdSlotOfTrap") == "dinamit") {
				trapInst = dinamitInst;
				gameObject.GetComponent<Image>().sprite = dinamitSprite;
			} else if (PlayerPrefs.GetString ("ThirdSlotOfTrap") == "ball") {
				trapInst = ballInst;
				gameObject.GetComponent<Image>().sprite = ballSprite;
			} else if(PlayerPrefs.GetString ("ThirdSlotOfTrap") == "apple" ){
				trapInst = appleInst;
				gameObject.GetComponent<Image>().sprite = appleSprite;	
			} else if(PlayerPrefs.GetString ("ThirdSlotOfTrap") == "flag"){
				trapInst = flagInst;
				gameObject.GetComponent<Image>().sprite = flagSprite;
			}
		} else if (numberOfSlot == 4f) {
			if (PlayerPrefs.GetString ("FourthSlotOfTrap") == "dinamit") {
				trapInst = dinamitInst;
				gameObject.GetComponent<Image>().sprite = dinamitSprite;
			} else if (PlayerPrefs.GetString ("FourthSlotOfTrap") == "ball") {
				trapInst = ballInst;
				gameObject.GetComponent<Image>().sprite = ballSprite;
			} else if(PlayerPrefs.GetString ("FourthSlotOfTrap") == "apple" ){
				trapInst = appleInst;
				gameObject.GetComponent<Image>().sprite = appleSprite;	
			} else if(PlayerPrefs.GetString ("FourthSlotOfTrap") == "flag"){
				trapInst = flagInst;
				gameObject.GetComponent<Image>().sprite = flagSprite;
			}
		}
		*/

		//anim = GetComponent<Animator>();
		PlayerPrefs.SetString ("FirstSlotOfTrap", "naruchniki");
		PlayerPrefs.SetString ("SecondSlotOfTrap", "svist");
		if (numberOfSlot == 1f) {
			if (PlayerPrefs.GetString ("FirstSlotOfTrap") == "svist") {
				trapInst = naruchnikiInst;
				gameObject.GetComponent<Image>().sprite = naruchnikiSprite;
			} else if (PlayerPrefs.GetString ("FirstSlotOfTrap") == "naruchniki") {
				trapInst = svistInst;
				gameObject.GetComponent<Image>().sprite = svistSprite;
			}
		} else if (numberOfSlot == 2f) {
			if (PlayerPrefs.GetString ("SecondSlotOfTrap") == "svist") {
				trapInst = naruchnikiInst;
				gameObject.GetComponent<Image>().sprite = naruchnikiSprite;
			} else if (PlayerPrefs.GetString ("SecondSlotOfTrap") == "naruchniki") {
				trapInst = svistInst;
				gameObject.GetComponent<Image>().sprite = svistSprite;
			}
		}

	}
	void Awake(){
		//anim = GetComponent<Animator>();
	}
}
