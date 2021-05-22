using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrabCoins : MonoBehaviour {
	static public int w = 0;



	void OnMouseDown () {
		//gameObject.SetActive (gameObject);
		Text  q = GetComponentInParent(typeof(Text)) as Text;
		w += 1;
		q.text = "Coins: " + w.ToString();
		PlayerPrefs.SetInt ("TextCoinsInLevel", w);
		gameObject.GetComponent<Renderer>().enabled = false;
		print ("собрал монету");
		gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
		Destroy (gameObject, 5f);
		//UpdateText();
	}


	/*
	void Update(){
		if(Input.GetMouseButtonUp(0)){
			Collider2D[] colliders = Physics2D.OverlapPointAll(new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)).x, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)).y));
			print (new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)).x, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)).y));
			if(colliders.Length >= 1){
				foreach(var collider in colliders){
					if(collider.gameObject.name.Contains("Coin")){
						Text  q = GetComponentInParent(typeof(Text)) as Text;
						w += 1;
						q.text = "Coins: " + w.ToString();
						PlayerPrefs.SetInt ("TextCoinsInLevel", w);
						gameObject.GetComponent<Renderer>().enabled = false;
						print ("собрал монету");
						gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
						Destroy (gameObject, 5f);
						//UpdateText();
					}
				}
			}
		}
	}
	*/

	void UpdateText(){
		UpdateTextCustomComponent updateTextCustomComponentInst = this.gameObject.AddComponent (typeof(UpdateTextCustomComponent)) as UpdateTextCustomComponent;
		Destroy (this.gameObject, 1f);				
	}
	/*
	void OnDestroy(){
		
	}
	*/
}
