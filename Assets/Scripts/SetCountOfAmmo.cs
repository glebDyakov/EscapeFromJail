using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountOfAmmo : MonoBehaviour {
	public GameObject ammoPrefab;
	public Animator anim;
	public List<GameObject> bullets;
	[SerializeField]
	public GameObject allAmmos;
	// Use this for initialization
	public void Start () {
		//пока просто так задаем начальное оружие пистолет дальше это будет происходить через магазин
		PlayerPrefs.SetString ("SelectedWeapon", "Pistol");
		//PlayerPrefs.SetInt ("CountAmmo", 5);

		// взависимости какое выбрано оружие будет даваться нужное количество патронов
		//if (PlayerPrefs.GetString ("SelectedWeapon") == "Pistol") {
			PlayerPrefs.SetInt ("CountAmmo", 2);
		//}
		ShowAmmo ();

	}
	public void HideAmmo(){
		//Destroy ();

		for (int ammoIndex = 0; ammoIndex  < PlayerPrefs.GetInt("CountAmmo"); ammoIndex++) {
			bullets.Remove(bullets[bullets.Count - 1]);
			//allAmmos.transform.GetChild (bullets.Count - 1);
			//ammoIndex < allAmmos.transform.childCount;
			//print (allAmmos.transform.childCount);
			//Destroy (allAmmos.transform.GetChild (ammoIndex).gameObject, 0f);
			//allAmmos.transform.GetChild(allAmmos.transform.childCount - 1);
		}

		/*
		int ammo = 0;
		while(ammo < allAmmos.transform.childCount) {
			print (allAmmos.transform.childCount);
			//Destroy (allAmmos.transform.GetChild (ammoIndex).gameObject, 0f);
			//allAmmos.transform.GetChild(allAmmos.transform.childCount - 1);
		}
		*/


	}

	public void ShowAmmo(){
		for (int ammo = 0; ammo < PlayerPrefs.GetInt ("CountAmmo"); ammo++) {
			GameObject ammoOne = Instantiate (ammoPrefab, new Vector2(-12f + ammo, 5f), Quaternion.Euler(0f, 0f, 50f));
			ammoOne.transform.parent = allAmmos.transform;
			bullets.Add (ammoOne);
		}
		//anim.Play("O_p-0");

		//print (allAmmos.transform.GetChild(allAmmos.transform.childCount - 1));
	}
	/*
	public void Update(){
		if (PlayerPrefs.GetInt ("CountAmmo") < allAmmos.transform.childCount) {
			HideAmmo ();
			ShowAmmo ();
		} else {
			print ("синхронизация картинок патронов и количества пуль не нужна");
		}
	}
	*/

}
