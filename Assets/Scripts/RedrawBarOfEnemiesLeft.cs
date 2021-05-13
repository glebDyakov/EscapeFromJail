using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedrawBarOfEnemiesLeft : MonoBehaviour {

	public static float barScale;

	public static bool Redraw(){
		//float countOfZeks = 5f;
		//float countOfZeks = 16f / SpawnZek.countOfZeks;
		//GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale= new Vector2(16f / 5f, 5f);
		GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale = new Vector2(GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale.x - (barScale / SpawnZek.countOfZeks), GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale.y);
		if (GameObject.FindGameObjectWithTag ("EnemiesLeft").transform.localScale.x <= 0f) {
			return true;
		}
		return false;
	}
	public void Start(){
		barScale = GameObject.FindGameObjectWithTag("EnemiesLeft").transform.localScale.x;
	}
}
