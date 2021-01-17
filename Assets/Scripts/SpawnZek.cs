using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnZek : MonoBehaviour {
	public GameObject allZeks;
	public GameObject zek;
	public static int countOfZeks;
	public float zekPosition = 8.65f;
	public float[] possibleZekYPosition = new float[]{-1.6f, -2f, -2.65f};

	void Update(){
		if (gameObject.transform.childCount == 0) {
			SceneManager.LoadScene ("Menu");
		}
	}
	void Start () {
		StartCoroutine (Spawn ());

	}

	IEnumerator MoveZek(GameObject zek){
		
		while (zekPosition != -0.8f) {
			if (zekPosition != 8.6f) {
				zekPosition -= 0.2f;
			} else {
				zekPosition = 8.4f;
			}
			zek.transform.position = new Vector2(zekPosition, zek.transform.position.y);
			yield return new WaitForSeconds (1f);
		}
	}

	IEnumerator Spawn(){
		for (int zekInt = 0; zekInt < 5; zekInt++) {
			//StartCoroutine(MoveZek(Instantiate (zek, new Vector2 (8.65f, -1.14f), Quaternion.identity)));
			//if(transform.childCount < 5){
			GameObject zekprefab = Instantiate (zek, new Vector2 (5f, possibleZekYPosition[Random.Range(0, possibleZekYPosition.Length)]), Quaternion.identity);
			zekprefab.transform.parent = allZeks.transform;
				yield return new WaitForSeconds (2f);
			//}
		}
	}
}
