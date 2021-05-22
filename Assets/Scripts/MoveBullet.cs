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
			//gameObject.transform.position = Vector2.MoveTowards (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), finishPosition.y < 0f ? new Vector2(finishPosition.x * -10f, finishPosition.y) : new Vector2(finishPosition.x * 10f, finishPosition.y), Time.deltaTime * 5f);
			gameObject.transform.position = Vector2.MoveTowards (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), finishPosition, Time.deltaTime * 5f);
		} else if(Vector2.Distance(gameObject.transform.position, finishPosition) <= 0.2f){
			//finishPosition *= 2;
			//gameObject.transform.position = Vector2.MoveTowards (new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), finishPosition, Time.deltaTime * 5f);

			//finishPosition = new Vector2(gameObject.transform.InverseTransformPoint(gameObject.transform.position).x + 25f, 0f);

			//finishPosition = new Vector2(gameObject.transform.InverseTransformPoint(gameObject.transform.position).x * 10f, gameObject.transform.InverseTransformPoint(gameObject.transform.position).y * 10f);

			/*
			int posX = 1;
			if (finishPosition.x < 0) {
				posX = -1;
			} else if (finishPosition.x >= 0) {
				posX = 1;
			}
			Vector2 newPos = new Vector2(10f * posX, 0);
			finishPosition = gameObject.transform.InverseTransformVector(gameObject.transform.position) + new Vector3(newPos.x, newPos.y, 0f);
			*/

			//finishPosition = gameObject.transform.localPosition * 10f;

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
