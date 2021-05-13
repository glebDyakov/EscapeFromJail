using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowOfUnavailableLevel : MonoBehaviour {
	public GameObject windowOfLevelUnavailable;
	void Start () {
		windowOfLevelUnavailable.SetActive (false);
	}
}
