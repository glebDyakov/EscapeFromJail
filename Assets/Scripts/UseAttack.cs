//Анимация наручников
//anim.Play("O_nar-0");

//Анимация свистка
//anim.Play("O_svist");
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAttack : MonoBehaviour {
	public Animator anim;
	GameObject trapInst;
	public float strike;
	public float numberOfSlot;
	int counter = 0;
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
	// Use this for initialization
	void OnMouseDrag () {
		counter++;
		if(counter == 1){
			startPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition[0], Input.mousePosition[1]));
		}
		print ("атака");
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition[0], Input.mousePosition[1]));
	}
	void OnMouseUp () {
		toPosition = gameObject.transform.position;
		Invoke("ResetPosition", 0.5f);
	}
	void ResetPosition(){
		gameObject.transform.position = startPosition;
		dinamitInstPrefab = Instantiate (trapInst, new Vector2(-8.75f, -2.35f), Quaternion.identity);	
		/*
		if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "dinamit" || PlayerPrefs.GetString ("SecondSlotOfTrap") == "dinamit" || PlayerPrefs.GetString ("ThirdSlotOfTrap") == "dinamit" || PlayerPrefs.GetString ("FourthSlotOfTrap") == "dinamit"){
			dinamitInstPrefab = Instantiate (dinamitInst);		
		} else if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "ball"  || PlayerPrefs.GetString ("SecondSlotOfTrap") == "ball"  || PlayerPrefs.GetString ("ThirdSlotOfTrap") == "ball"  || PlayerPrefs.GetString ("FourthSlotOfTrap") == "ball"){
			dinamitInstPrefab = Instantiate (ballInst);		
		}  else if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "apple"  || PlayerPrefs.GetString ("SecondSlotOfTrap") == "apple"  || PlayerPrefs.GetString ("ThirdSlotOfTrap") == "apple"  || PlayerPrefs.GetString ("FourthSlotOfTrap") == "apple"){
			dinamitInstPrefab = Instantiate (appleInst);		
		} else if(PlayerPrefs.GetString ("FirstSlotOfTrap") == "flag"  || PlayerPrefs.GetString ("SecondSlotOfTrap") == "flag"  || PlayerPrefs.GetString ("ThirdSlotOfTrap") == "flag"  || PlayerPrefs.GetString ("FourthSlotOfTrap") == "flag"){
			dinamitInstPrefab = Instantiate (flagInst);		
		}
		*/

		/*
		if (dinamitInstPrefab.name == "apple" || dinamitInstPrefab.name == "apple(Clone)") {
			Rigidbody2D dinamitInstrb = dinamitInstPrefab.GetComponent<Rigidbody2D> ();
			dinamitInstrb.AddRelativeForce (toPosition * strike, ForceMode2D.Impulse);
			Invoke ("DestroyWeapon", 0.5f);
		}
		*/

		/*
		раньше начиная с этой строки было не закомментировано и работало
		if (dinamitInstPrefab.name.Contains("apple") || dinamitInstPrefab.name.Contains("ball") || dinamitInstPrefab.name.Contains("flag") || dinamitInstPrefab.name.Contains("dinamit")) {
			Rigidbody2D dinamitInstrb = dinamitInstPrefab.GetComponent<Rigidbody2D> ();
			dinamitInstrb.AddRelativeForce (toPosition * strike, ForceMode2D.Impulse);
			//dinamitInstrb.AddRelativeForce (new Vector2(250, 50f), ForceMode2D.Impulse);
			if(dinamitInstPrefab.name.Contains("apple")){
				//анимация с яблоком
				anim.Play("O_svist");
			} else if(dinamitInstPrefab.name.Contains("ball")){
				//анимация с мячом
				anim.Play("O_svist");
			}  else if(dinamitInstPrefab.name.Contains("flag")){
				//анимация с флагом
				anim.Play("O_svist");
			}  else if(dinamitInstPrefab.name.Contains("dinamit")){
				//анимация с динамитом
				anim.Play("O_svist");
			} 
			Invoke ("DestroyWeapon", 0.5f);
		}

		*/


		if (dinamitInstPrefab.name.Contains("svist") || dinamitInstPrefab.name.Contains("naruchniki")) {
			Rigidbody2D dinamitInstrb = dinamitInstPrefab.GetComponent<Rigidbody2D> ();
			dinamitInstrb.AddRelativeForce (toPosition * strike, ForceMode2D.Impulse);
			//dinamitInstrb.AddRelativeForce (new Vector2(250, 50f), ForceMode2D.Impulse);
			if(dinamitInstPrefab.name.Contains("svist")){
				//анимация с яблоком
				anim.Play("O_svist");
			} else if(dinamitInstPrefab.name.Contains("naruchniki")){
				//анимация с мячом
				anim.Play("O_nar-0");
			}
			Invoke ("DestroyWeapon", 0.5f);
		}

	}
	void DestroyWeapon(){
		Destroy (dinamitInstPrefab, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Start(){
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
