using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhranikAnimator : MonoBehaviour {
	 Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}
	void tooglePist(){
		anim.SetInteger("anim", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
