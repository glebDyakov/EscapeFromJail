using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByLevelList : MonoBehaviour {

	public Vector3 rastoyanie;
	public GameObject firstLevel;
	public GameObject lastLevel;
	public int counter = 0;
	Vector3 mousePos;
	public UnityEngine.UI.Text coins;
	public UnityEngine.UI.Text elixirCount;
	public bool doOnce;


	public void Start(){
		if (doOnce) {
			coins.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();
			elixirCount.text = PlayerPrefs.GetInt ("ElixirsCount").ToString ();
		}
	}

	void Update(){
		if (Input.GetMouseButtonUp(0)) {
			counter = 0;
		}

		if(Input.GetButton("Fire1")){
			if (counter == 0) {
				counter++;
				mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition [0], Input.mousePosition [1], 0f));
				rastoyanie = mousePos - new Vector3 (firstLevel.transform.position.x, mousePos.y, 0f); 
				
			} else {
				/*
				int sign = 0;
				if (gameObject.transform.position.x + gameObject.transform.localScale.x < mousePos.x) {
					sign = -1;
				} else if (gameObject.transform.position.x + gameObject.transform.localScale.x > mousePos.x) {
					sign = 1;
				}
				*/

				int sign = 0;
				if (Camera.main.transform.position.x + Camera.main.transform.localScale.x / 2f < mousePos.x) {
					sign = 1;
				} else if (Camera.main.transform.position.x + Camera.main.transform.localScale.x / 2f >= mousePos.x) {
					sign = -1;
				}

				/*
				if (gameObject.transform.position.x < mousePos.x) {
					firstLevel = gameObject;
				} else if (gameObject.transform.position.x > mousePos.x) {
				
				}
				*/
				//gameObject.transform.position -= rastoyanie * 0.02f * sign;
				//gameObject.transform.position -= rastoyanie * 0.02f;
				
				if(((firstLevel.transform.position - Vector3.right * 0.5f * sign).x <= Camera.main.transform.position.x) && ((lastLevel.transform.position - Vector3.right * 0.5f * sign).x >= Camera.main.transform.position.x)){
					gameObject.transform.position -= Vector3.right * 0.5f * sign;
				}

				//gameObject.transform.position = new Vector2 (gameObject.transform.position.x + 10f, gameObject.transform.position.y); 
			}
		}
	}
	/*
	void OnMouseUp(){
		counter = 0;
	}
	*/

}
