using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsPlay : MonoBehaviour {

	void OnMouseDown () {
		SceneManager.LoadScene ("Main");
	}
}
