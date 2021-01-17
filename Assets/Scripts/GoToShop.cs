using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToShop : MonoBehaviour {

	void OnMouseDown () {
		SceneManager.LoadScene ("Shop");
	}
}
