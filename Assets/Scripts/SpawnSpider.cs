using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour {
	public float animationSpriderTime = 5f;
	public GameObject spider;
	public GameObject allSpiders;
	GameObject spiderprefab;

	void Start () {
		
		StartCoroutine (Spawn ());

	}
	/*void Update(){
		if (spiderprefab != null && spiderprefab.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime == 1.0f) {
			Destroy (spiderprefab);	
			spiderprefab = null;
			print("pauk destroy");
		}
	}*/

	IEnumerator Spawn(){
		//spiderprefab = null;
		while (true) {
			
			/*if (spiderprefab != null) {
				Destroy (spiderprefab);	
			}*/

			float isSpider = Random.Range (1f, 6f);
			if (spiderprefab != null >= 3f) {
				Destroy (spiderprefab);	
			}
			else if (spiderprefab == null && isSpider >= 3f) {
				Destroy (spiderprefab);	
				spiderprefab = Instantiate (spider, new Vector2 (Random.Range (-5.7f, 5.7f), 4f), Quaternion.Euler (0f, 0f, 0f));
				spiderprefab.transform.parent = allSpiders.transform;

			} 
			print (isSpider);
			yield return new WaitForSeconds (animationSpriderTime);
		}
	}
	void DestroySpider(){
		Destroy (spiderprefab);
	}

}
