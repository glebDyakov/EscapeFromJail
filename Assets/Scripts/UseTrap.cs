using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/*
	void OnTriggerEnter2D (Collider2D other) {
		if (gameObject.name == "dinamit") {
			if (other.gameObject.tag == "zek") {

			}
		} else if (gameObject.name == "flag") {
			if (other.gameObject.tag == "zek") {

			}
		} else if(gameObject.name == "ball") {
			if (other.gameObject.tag == "zek") {

			}
		} else if (gameObject.name == "apple") {
			if (other.gameObject.tag == "zek") {

			}
		}
	}
	*/
	void Update(){
		if (gameObject.name != "apple" && gameObject.name != "apple(Clone)") {
			gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, UseAttack.toPosition, 2f);
			if(gameObject.transform.position.Equals(UseAttack.toPosition) ){
				Destroy(gameObject, 0f);
			}
		}
	}
}
