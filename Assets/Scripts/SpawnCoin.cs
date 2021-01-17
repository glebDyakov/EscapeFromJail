using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour {
	public GameObject coin;
	public GameObject allCoins;

	void Start () {
		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn(){
		while (true) {
			float isCoin = Random.Range (1f, 6f);
			if (isCoin < 5f) {		
				GameObject coinprefab = Instantiate (coin, new Vector2 (Random.Range (-5.5f, 0f), Random.Range (5.2f, 5.8f)), Quaternion.identity);
				//coinprefab.transform.parent = allCoins.transform;
				coinprefab.transform.parent = allCoins.transform;
			}
			yield return new WaitForSeconds (5f);
		}
	}

}
