using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour {

	public float randomTime;
	public GameObject coin;
	public GameObject allCoins;

	void Start () {
		//StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn(){
		while (true) {
			float isCoin = Random.Range (1f, 6f);
			if (isCoin < 5f) {		
				Vector2 coinPosition = new Vector2 (Random.Range (-5.5f, -3.52f), Random.Range (5.2f, -4.82f));
				GameObject coinprefab = Instantiate (coin, coinPosition, Quaternion.identity);
				coinprefab.transform.parent = allCoins.transform;
			}
			randomTime = Random.Range (15f, 45f);
			//yield return new WaitForSeconds (randomTime);
			//ниже надо убрать
			yield return new WaitForSeconds (5f);
		}

	}
	public void RulkaCoin(GameObject zeckPos){
		GameObject coinprefab = Instantiate (coin, new Vector2(zeckPos.transform.position.x,zeckPos.transform.position.y), Quaternion.identity);
		coinprefab.transform.parent = allCoins.transform;
		if(coinprefab){
		Destroy (coinprefab,3f);
		}
	}

}
