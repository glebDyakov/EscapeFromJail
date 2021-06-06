using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsForButtons : MonoBehaviour {

	public UnityEngine.UI.Text countOfBulletOfShootgun;
	public GameObject ammos;
	public Animator animat;
	public string isButtonFor = "changeWeapon";
	public static string selectedWeapon = "Pistol";
	public ShotBullet shotBullet;
	public SetCountOfAmmo setCountOfAmmo;

	void OnMouseDown () {
		if(isButtonFor.Contains("changeWeapon")){
			if (selectedWeapon.Contains("Shootgun")) {
				SetCountOfAmmo.countAmmo = PlayerPrefs.GetInt ("CountAmmo");
				selectedWeapon = "Pistol";
				animat.Play("O_p-0");
				for(int ammo = 0; ammo < ammos.transform.childCount; ammo++){
					Destroy (setCountOfAmmo.bullets [setCountOfAmmo.bullets.Count - 1]);
					setCountOfAmmo.bullets.Remove (setCountOfAmmo.bullets [setCountOfAmmo.bullets.Count - 1]);	
				}

				//setCountOfAmmo.ShowAmmo ();
				shotBullet.ShowAmmo ();

			} else if (selectedWeapon.Contains("Pistol") && PlayerPrefs.GetInt ("CountShootgunAmmo") >= 1) {
				SetCountOfAmmo.countAmmo = 2;
				selectedWeapon = "Shootgun";
				animat.Play("O_p-0");
				for(int ammo = 0; ammo < ammos.transform.childCount; ammo++){
					Destroy (setCountOfAmmo.bullets [setCountOfAmmo.bullets.Count - 1]);
					setCountOfAmmo.bullets.Remove (setCountOfAmmo.bullets [setCountOfAmmo.bullets.Count - 1]);	
				}

				//setCountOfAmmo.ShowAmmo ();
				shotBullet.ShowAmmo ();

			}
			print (selectedWeapon);
		}
	}
	

	void Start () {
		if (isButtonFor.Contains ("changeWeapon")) {
			countOfBulletOfShootgun.text = PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
		}
	}
}
