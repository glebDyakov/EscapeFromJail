using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
	public Vector2 finishPosition;
	/*
	float posX;
	float posY;
	*/
	public bool pressed = false;
	void Start(){
		finishPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition [0], Input.mousePosition [1]));
		Vector2 diff = finishPosition - new Vector2(transform.position.x, transform.position.y);
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
	void OnMouseUp(){
		pressed = true;

	}
	void Update(){
		/*
		if (pressed) {
			if (gameObject.transform.position != Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition [0], Input.mousePosition [1]))) {
				gameObject.transform.position = Vector2.MoveTowards (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition [0], Input.mousePosition [1])), 2f);
			} else {
				Destroy (gameObject, 1f);
			}
		}
		*/
		if(Vector2.Distance(gameObject.transform.position, finishPosition) > 0.2f){
			gameObject.transform.position = Vector2.MoveTowards (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), finishPosition, Time.deltaTime * 5f);
		} else if(Vector2.Distance(gameObject.transform.position, finishPosition) <= 0.2f){
			Destroy (gameObject);
		}
	}
	/*
	void OnMouseUp () {
		posX = Input.mousePosition [0];
		posY = Input.mousePosition [1];
	}
	

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().MovePosition(new Vector2(posX, posY) + new Vector2(0.2f,0.2f) * Time.fixedDeltaTime);
	}
	*/
}
