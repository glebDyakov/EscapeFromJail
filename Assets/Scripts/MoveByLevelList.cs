using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByLevelList : MonoBehaviour {
	public Vector3 rastoyanie;
	public GameObject firstLevel;
	public int counter = 0;
	Vector3 mousePos;
	void Update(){
		if (Input.GetMouseButtonUp(0)) {
			counter = 0;
		}

		if(Input.GetButton("Fire1")){
			if (counter == 0) {
				counter++;
				mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition [0], Input.mousePosition [1], 0f));
				rastoyanie = mousePos -  new Vector3 (firstLevel.transform.position.x, mousePos.y, 0f); 
				
			} else {
				gameObject.transform.position -= rastoyanie * 0.02f;
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
