using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsClick : MonoBehaviour {

	public Animator animat;
	public GameObject healthBarOfWatcher;
	public GameObject allZeks;

	public void Dubinka(){
		animat.Play("O_dub-1");
	}

	public void LoadMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void RepairLife(){
		/*
		healthBarOfWatcher.transform.localScale = new Vector2 (1f, healthBarOfWatcher.transform.localScale.y);
		for(int child = 0; child < allZeks.transform.childCount - 1; child++){
			Destroy(allZeks.transform.GetChild(child).gameObject);
		}
		*/
	}

	public void RespawnCop(){
		//увеличить ХП охраника и уничтожать всех зеков
		this.SendMessage("RepairLife");
		animat.Play("O_P-0");
	}
}
