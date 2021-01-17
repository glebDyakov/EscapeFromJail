using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHome : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown () {
		SceneManager.LoadScene ("Menu");
	}
}
