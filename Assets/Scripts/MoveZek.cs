using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZek : MonoBehaviour {
	public float speed = 0.2f;
	//transform.position = new Vector2 ();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -1.555555f) {
			if(transform.position.x < -1f){
				if(transform.position.y > -2.25f){
					transform.Translate (Vector2.up * -(Time.deltaTime * speed));
				}else if(transform.position.y < -2.25f){
					transform.Translate (Vector2.up * (Time.deltaTime * speed));
				}
			}
			transform.Translate (Vector2.right * -(Time.deltaTime * speed));
		

			//transform.position = new Vector2 ();		
		} else {
			
			//GetComponent<Animation>.clip = zekKick;
			gameObject.GetComponent<Animation>().Play();
		}		
	}
}
