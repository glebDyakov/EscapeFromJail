using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnZek : MonoBehaviour {
	public float positionY;
	public GameObject allZeks;
	List<GameObject> listOfEvilCharacters;

	public GameObject zek;
	public GameObject bigZek;
	public static int countOfZeks = 5;
	public float zekPosition = 8.65f;
	public float[] possibleZekYPosition = new float[]{-1.5f, -2.5f, -3.7f};
	public int Wave=1;


	/*
	void Update(){
		if (gameObject.transform.childCount == 0) {
			SceneManager.LoadScene ("Menu");
		}
	}
	*/

	void Start () {
		if (Wave > 0) {
			listOfEvilCharacters = new List<GameObject>{ zek, bigZek };
			StartCoroutine (Spawn ());
		}

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

	public IEnumerator Spawn(){
		for (int zekInt = 0; zekInt < SpawnZek.countOfZeks * Wave; zekInt++) {
			//StartCoroutine(MoveZek(Instantiate (zek, new Vector2 (8.65f, -1.14f), Quaternion.identity)));
			//if(transform.childCount < 5){
			GameObject randomZek = listOfEvilCharacters[Random.Range(0, listOfEvilCharacters.Count)];
			positionY = possibleZekYPosition[Random.Range(0, possibleZekYPosition.Length)];
			GameObject zekprefab = Instantiate (zek, new Vector2 (14f, positionY), Quaternion.identity);
			zekprefab.transform.parent = allZeks.transform;
			zekprefab.transform.localPosition = new Vector2 (zekprefab.transform.localPosition.x, positionY);
				
			if (positionY == possibleZekYPosition [1]) {
				zekprefab.GetComponent<MoveZek> ().destination = -7.600000f;
				zekprefab.GetComponent<MoveZek> ().rowOfZek = 2;
				zekprefab.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
				zekprefab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
				zekprefab.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowTwo";
			} else if(positionY == possibleZekYPosition [0] || positionY == possibleZekYPosition [2]){
				zekprefab.GetComponent<MoveZek> ().destination = -5.000000f;
				if (positionY == possibleZekYPosition [0]) {
					zekprefab.GetComponent<MoveZek> ().rowOfZek = 1;
					zekprefab.GetComponent<SpriteRenderer> ().sortingLayerName = "RowOne";
					zekprefab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowOne";
					zekprefab.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowOne";
				} else if (positionY == possibleZekYPosition [2]) {
					zekprefab.GetComponent<MoveZek> ().rowOfZek = 3;
					zekprefab.GetComponent<SpriteRenderer> ().sortingLayerName = "RowThree";
					zekprefab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowThree";
					zekprefab.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "RowThree";
				}
			}
			yield return new WaitForSeconds (2f);
			//}
		}
	}
}
