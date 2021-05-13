using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class RepairLife : MonoBehaviour {
	public Text digit;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("DigitLess", 2f, 2f);	
	}
	
	// Update is called once per frame
	void  DigitLess() {
		digit.text = (int.Parse(digit.text) - 1).ToString();
		if (int.Parse (digit.text) <= 0) {
			SceneManager.LoadScene ("Menu");
		}
	}
}
