using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chpok : MonoBehaviour {
	public AudioSource chpokAudio;
	void OnMouseDown(){
		chpokAudio = gameObject.GetComponent<AudioSource>() ;
		chpokAudio.Play ();
	}
}
