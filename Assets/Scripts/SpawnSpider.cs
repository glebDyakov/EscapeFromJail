using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour {
	public float animationSpriderTime = 2f;
	public GameObject spider;
	public GameObject allSpiders;

	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn(){
		GameObject spiderprefab = null;
		while (true) {
			
			if (spiderprefab != null) {
				Destroy (spiderprefab);	
			}
			float isSpider = Random.Range (1f, 6f);
			if (isSpider <= 3f) {		
			spiderprefab = Instantiate (spider, new Vector2 (Random.Range (7.8f, 15f), 8f), Quaternion.Euler(0f, 0f, -90f));
				spiderprefab.transform.parent = allSpiders.transform;

			}
			print (isSpider);
			yield return new WaitForSeconds (animationSpriderTime);
		}
	}

}
